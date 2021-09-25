using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class SixDependencyTest
{
    [Fact]
    public void WithTwoResolvers_SeventhIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => SomeString,
            _ => MinusFifteenIdRefType,
            _ => decimal.MaxValue,
            _ => new object(),
            _ => DateTimeKind.Unspecified,
            _ => SomeTextStructType);

        var restValue = PlusFifteenIdLowerSomeStringNameRecord;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                (Func<IServiceProvider, long?[]>)null!,
                _ => restValue));

        Assert.Equal("seventh", ex.ParamName);
    }

    [Fact]
    public void WithTwoResolvers_RestIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => SomeTextStructType,
            _ => MinusOne,
            _ => UpperSomeString,
            _ => decimal.MaxValue,
            _ => PlusFifteenIdSomeStringNameRecord,
            _ => DateTimeKind.Local);

        var seventhValue = ZeroIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => seventhValue,
                (Func<IServiceProvider, DateTime>)null!));

        Assert.Equal("rest", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void WithTwoResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        RefType? lastValue)
    {
        var firstSource = SomeTextStructType;
        var secondSource = MinusFifteen;

        var thirdSource = true;
        var fourthSource = decimal.One;

        var fifthSource = new { Name = SomeString };
        var sixthSource = MinusFifteenIdSomeStringNameRecord;

        var source = Dependency.From(
            _ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource, _ => sixthSource);

        var seventhValue = long.MinValue;

        var actual = source.With(_ => seventhValue, _ => lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = ((firstSource, secondSource, thirdSource, fourthSource), (fifthSource, sixthSource, seventhValue, lastValue));
        Assert.Equal(expectedValue, actualValue);
    }
}
