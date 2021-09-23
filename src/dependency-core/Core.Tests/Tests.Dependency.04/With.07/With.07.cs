using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FourDependencyTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    [InlineData(SomeString)]
    public void WithThree_ExpectResolvedValuesAreEqualToSourceAndOther(
        string lastValue)
    {
        var firstSource = TabString;
        var secondSource = MinusFifteenIdNullNameRecord;

        var thirdSource = SomeTextStructType;
        var fourthSource = long.MinValue;

        var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource);

        var fifthValue = PlusFifteenIdRefType;
        var sixthValue = new[] { long.MinValue, long.MaxValue };

        var actual = source.With(fifthValue, sixthValue, lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthValue, sixthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}
