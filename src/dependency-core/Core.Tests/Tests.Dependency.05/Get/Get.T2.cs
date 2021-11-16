using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FiveDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void GetSecond_ExpectResolvedValueIsEqualToSecondSource(
        RecordType secondSource)
    {
        var source = Dependency.From(
            _ => ZeroIdNullNameRecord,
            _ => secondSource,
            _ => MinusFifteen,
            _ => decimal.One,
            _ => PlusFifteenIdRefType);

        var actual = source.GetSecond();
        var actualValue = actual.Resolve();

        Assert.Equal(secondSource, actualValue);
    }
}