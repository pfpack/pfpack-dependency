using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class ThreeDependencyTest
{
    [Fact]
    public void WithThreeFactories_FourthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => new object(), _ => PlusFifteenIdRefType, _ => decimal.MinusOne);

        var fifthValue = MinusFifteenIdNullNameRecord;
        var sixthValue = true;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                (Func<StructType?>)null!,
                () => fifthValue,
                () => sixthValue));

        Assert.Equal("fourth", ex.ParamName);
    }

    [Fact]
    public void WithThreeFactories_FifthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => EmptyString, _ => PlusFifteenIdRefType, _ => DateTimeKind.Unspecified);

        var fourthValue = SomeTextStructType;
        var sixthValue = new { Value = decimal.One };

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => fourthValue,
                (Func<RecordType>)null!,
                () => sixthValue));

        Assert.Equal("fifth", ex.ParamName);
    }

    [Fact]
    public void WithThreeFactories_SixthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => ZeroIdNullNameRecord, _ => UpperSomeString, _ => long.MinValue);

        var fourthValue = new object();
        var fifthValue = LowerSomeTextStructType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => fourthValue,
                () => fifthValue,
                (Func<RefType?>)null!));

        Assert.Equal("sixth", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void WithThreeFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        RecordType? lastValue)
    {
        var firstSource = decimal.One;
        var secondSource = MinusFifteenIdRefType;

        var thirdSource = new object();
        var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource);

        var fourthValue = SomeTextStructType;
        var fifthValue = uint.MaxValue;

        var actual = source.With(() => fourthValue, () => fifthValue, () => lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdSource, fourthValue, fifthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}