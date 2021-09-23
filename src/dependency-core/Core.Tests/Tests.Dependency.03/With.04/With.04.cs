using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class ThreeDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void WithOne_ExpectResolvedValuesAreEqualToSourceAndOther(
        RefType fourthValue)
    {
        var firstSource = SomeTextStructType;
        var secondSource = new object();

        var thirdSource = MinusFifteenIdSomeStringNameRecord;
        var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource);

        var actual = source.With(fourthValue);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdSource, fourthValue);
        Assert.Equal(expectedValue, actualValue);
    }
}
