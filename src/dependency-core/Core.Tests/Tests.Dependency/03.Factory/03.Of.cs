using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class DependencyTest
{
    [Theory]
    [InlineData(null, byte.MaxValue)]
    [InlineData(SomeString, null)]
    [InlineData(EmptyString, byte.MinValue)]
    public void Of_03_ExpectResolvedValuesAreEqualToSource(
        string? sourceSecond, byte? sourceThird)
    {
        var sourceFirst = MinusFifteenIdSomeStringNameRecord;

        var actual = Dependency.Of(sourceFirst, sourceSecond, sourceThird);
        var actualValue = actual.Resolve();

        var expectedValue = (sourceFirst, sourceSecond, sourceThird);
        Assert.Equal(expectedValue, actualValue);
    }
}