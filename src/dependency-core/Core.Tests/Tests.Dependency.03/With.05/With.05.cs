using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class ThreeDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void WithTwo_ExpectResolvedValuesAreEqualToSourceAndOther(
        RefType? lastValue)
    {
        var firstSource = MixedWhiteSpacesString;
        var secondSource = new object();

        var thirdSource = SomeTextStructType;
        var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource);

        var fourthValue = MinusFifteenIdSomeStringNameRecord;

        var actual = source.With(fourthValue, lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdSource, fourthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}