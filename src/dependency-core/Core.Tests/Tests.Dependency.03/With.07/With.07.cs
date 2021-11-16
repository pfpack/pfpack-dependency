using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class ThreeDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void WithFour_ExpectResolvedValuesAreEqualToSourceAndOther(
        RefType lastValue)
    {
        var firstSource = true;
        var secondSource = SomeTextStructType;

        var thirdSource = new object();
        var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource);

        var fourthValue = long.MaxValue;
        var fifthValue = ZeroIdNullNameRecord;

        var sixthValue = byte.MaxValue;

        var actual = source.With(fourthValue, fifthValue, sixthValue, lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdSource, fourthValue, fifthValue, sixthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}