using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class TwoDependencyTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    [InlineData(SomeString)]
    public void WithThree_ExpectResolvedValuesAreEqualToSourceAndOther(
        string lastValue)
    {
        var firstSource = PlusFifteenIdRefType;
        var secondSource = decimal.MinusOne;

        var source = Dependency.From(_ => firstSource, _ => secondSource);

        var thirdValue = LowerSomeTextStructType;
        var fourthValue = MinusFifteenIdNullNameRecord;

        var actual = source.With(thirdValue, fourthValue, lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdValue, fourthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}