using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class SixDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void WithOne_ExpectResolvedValuesAreEqualToSourceAndOther(
        RecordType seventhValue)
    {
        var firstSource = SomeTextStructType;
        var secondSource = true;

        var thirdSource = new[] { long.MinValue };
        var fourthSource = decimal.One;

        var fifthSource = MinusFifteenIdRefType;
        var sixthSource = new object();

        var source = Dependency.From(
            _ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource, _ => sixthSource);

        var actual = source.With(seventhValue);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthSource, sixthSource, seventhValue);
        Assert.Equal(expectedValue, actualValue);
    }
}
