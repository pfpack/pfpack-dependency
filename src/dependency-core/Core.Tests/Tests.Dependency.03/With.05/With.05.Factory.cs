using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class ThreeDependencyTest
{
    [Fact]
    public void WithTwoFactories_FourthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => LowerSomeTextStructType, _ => PlusFifteenIdRefType, _ => long.MinValue);

        var fifthValue = ZeroIdNullNameRecord;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                (Func<RecordType>)null!,
                () => fifthValue));

        Assert.Equal("fourth", ex.ParamName);
    }

    [Fact]
    public void WithTwoFactories_FifthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => new object(), _ => SomeTextStructType, _ => MinusFifteenIdRefType);

        var fourthValue = PlusFifteenIdLowerSomeStringNameRecord;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => fourthValue,
                (Func<int?>)null!));

        Assert.Equal("fifth", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void WithTwoFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        StructType lastValue)
    {
        var firstSource = new { Value = decimal.MaxValue };
        var secondSource = DateTimeKind.Unspecified;

        var thirdSource = ZeroIdNullNameRecord;
        var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource);

        var fourthValue = PlusFifteenIdRefType;

        var actual = source.With(() => fourthValue, () => lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdSource, fourthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}