using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class OneDependencyTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    [InlineData(SomeString)]
    public void WithOne_ExpectResolvedValuesAreEqualToSourceAndOther(
        string secondValue)
    {
        var sourceValue = PlusFifteenIdRefType;
        var source = Dependency.From(_ => sourceValue);

        var actual = source.With(secondValue);
        var actualValue = actual.Resolve();

        var expectedValue = (sourceValue, secondValue);
        Assert.Equal(expectedValue, actualValue);
    }
}