using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class TwoDependencyTest
{
    [Fact]
    public void WithTwoResolvers_ThirdIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => SomeTextStructType, _ => MinusFifteenIdSomeStringNameRecord);
        var lastValue = ZeroIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                (Func<IServiceProvider, DateTimeOffset?>)null!,
                _ => lastValue));

        Assert.Equal("third", ex.ParamName);
    }

    [Fact]
    public void WithTwoResolvers_FourthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => PlusFifteenIdRefType, _ => MinusOne);
        var thirdValue = SomeTextStructType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => thirdValue,
                (Func<IServiceProvider, RecordType>)null!));

        Assert.Equal("fourth", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void WithTwoResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        StructType lastValue)
    {
        var firstSource = PlusFifteenIdRefType;
        var secondSource = SomeString;

        var source = Dependency.From(_ => firstSource, _ => secondSource);
        var thirdValue = ZeroIdNullNameRecord;

        var actual = source.With(_ => thirdValue, _ => lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}
