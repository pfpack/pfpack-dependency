using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class OneDependencyTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    [InlineData(SomeString)]
    public void WithFive_ExpectResolvedValuesAreEqualToSourceAndOther(
        string lastValue)
    {
        var sourceValue = new { Value = decimal.MaxValue };
        var source = Dependency.From(_ => sourceValue);

        var secondValue = LowerSomeTextStructType;
        var thirdValue = MixedWhiteSpacesString;

        var fourthValue = PlusFifteenIdRefType;
        var fifthValue = ZeroIdNullNameRecord;

        var actual = source.With(secondValue, thirdValue, fourthValue, fifthValue, lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (sourceValue, secondValue, thirdValue, fourthValue, fifthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}