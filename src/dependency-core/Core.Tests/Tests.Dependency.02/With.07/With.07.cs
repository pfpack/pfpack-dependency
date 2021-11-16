using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class TwoDependencyTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    [InlineData(SomeString)]
    public void WithFive_ExpectResolvedValuesAreEqualToSourceAndOther(
        string? lastValue)
    {
        var firstSource = PlusFifteenIdSomeStringNameRecord;
        var secondSource = byte.MaxValue;

        var source = Dependency.From(_ => firstSource, _ => secondSource);

        var thirdValue = false;
        var fourthValue = LowerSomeTextStructType;

        var fifthValue = decimal.MinusOne;
        var sixthValue = MinusFifteenIdRefType;

        var actual = source.With(thirdValue, fourthValue, fifthValue, sixthValue, lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdValue, fourthValue, fifthValue, sixthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}