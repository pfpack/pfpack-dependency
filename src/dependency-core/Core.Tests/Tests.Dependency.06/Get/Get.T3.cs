using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class SixDependencyTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(MinusFifteen)]
    [InlineData(Zero)]
    [InlineData(PlusFifteen)]
    public void GetThird_ExpectResolvedValueIsEqualToThirdSource(
        int? thirdSource)
    {
        var source = Dependency.From(
            _ => MinusFifteenIdNullNameRecord,
            _ => PlusFifteen,
            _ => thirdSource,
            _ => LowerSomeTextStructType,
            _ => WhiteSpaceString,
            _ => MinusFifteenIdRefType);

        var actual = source.GetThird();

        var actualValue = actual.Resolve();
        Assert.Equal(thirdSource, actualValue);
    }
}