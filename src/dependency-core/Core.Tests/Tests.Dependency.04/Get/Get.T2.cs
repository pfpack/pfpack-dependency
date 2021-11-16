using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FourDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void GetSecond_ExpectResolvedValueIsEqualToSecondSource(
        StructType secondSource)
    {
        var source = Dependency.From(
            _ => MinusFifteen, _ => secondSource, _ => PlusFifteenIdRefType, _ => ZeroIdNullNameRecord);

        var actual = source.GetSecond();
        var actualValue = actual.Resolve();

        Assert.Equal(secondSource, actualValue);
    }
}