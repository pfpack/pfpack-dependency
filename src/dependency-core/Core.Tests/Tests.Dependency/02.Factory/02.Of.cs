using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class DependencyTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    [InlineData(SomeString)]
    public void Of_02_ExpectResolvedValuesAreEqualToSource(
        string? sourceSecond)
    {
        var sourceFirst = PlusFifteenIdRefType;
        var actual = Dependency.Of(sourceFirst, sourceSecond);

        var actualValue = actual.Resolve();

        var expectedValue = (sourceFirst, sourceSecond);
        Assert.Equal(expectedValue, actualValue);
    }
}
