using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class SevenDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void GetSecond_ExpectResolvedValueIsEqualToSecondSource(
        StructType secondSource)
    {
        var source = Dependency.From(
            _ => MinusFifteen,
            _ => secondSource,
            _ => ZeroIdNullNameRecord,
            _ => SomeString,
            _ => new { Amount = decimal.One },
            _ => false,
            _ => PlusFifteenIdRefType);

        var actual = source.GetSecond();
        var actualValue = actual.Resolve();

        Assert.Equal(secondSource, actualValue);
    }
}
