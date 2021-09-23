using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class TwoDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void WithFour_ExpectResolvedValuesAreEqualToSourceAndOther(
        RecordType? lastValue)
    {
        var firstSource = SomeTextStructType;
        var secondSource = new object();

        var source = Dependency.From(_ => firstSource, _ => secondSource);

        var thirdValue = MinusFifteenIdRefType;
        var fourthValue = long.MinValue;

        var fifthValue = false;

        var actual = source.With(thirdValue, fourthValue, fifthValue, lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdValue, fourthValue, fifthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}
