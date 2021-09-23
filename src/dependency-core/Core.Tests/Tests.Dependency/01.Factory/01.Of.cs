using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class DependencyTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    [InlineData(SomeString)]
    public void Of_01_ExpectResolvedValueIsEqualToSource(
        string? sourceSingle)
    {
        var actual = Dependency.Of(sourceSingle);
        var actualValue = actual.Resolve();

        Assert.Equal(sourceSingle, actualValue);
    }
}