using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class SevenDependencyTest
{
    [Fact]
    public void WithOneFactory_RestIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => SomeTextStructType,
            _ => DateTimeKind.Unspecified,
            _ => decimal.MaxValue,
            _ => One,
            _ => true,
            _ => PlusFifteenIdSomeStringNameRecord,
            _ => WhiteSpaceString);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With((Func<RefType>)null!));

        Assert.Equal("rest", ex.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(MinusOne)]
    [InlineData(Zero)]
    public void WithOneFactory_RestIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        int? restValue)
    {
        var firstSource = new object();
        var secondSource = LowerSomeTextStructType;

        var thirdSource = decimal.MinValue;
        var fourthSource = false;

        var fifthSource = byte.MaxValue;
        var sixthSource = MinusFifteenIdSomeStringNameRecord;

        var seventhSource = PlusFifteenIdRefType;

        var source = Dependency.From(
            _ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource, _ => sixthSource, _ => seventhSource);

        var actual = source.With(() => restValue);
        var actualValue = actual.Resolve();

        var expectedValue = ((firstSource, secondSource, thirdSource, fourthSource), (fifthSource, sixthSource, seventhSource, restValue));
        Assert.Equal(expectedValue, actualValue);
    }
}