using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class SevenDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void GetSixth_ExpectResolvedValueIsEqualToSixthSource(
        RefType sixthSource)
    {
        var source = Dependency.From(
            _ => MinusFifteenIdNullNameRecord,
            _ => TabString,
            _ => byte.MaxValue,
            _ => new object(),
            _ => SomeTextStructType,
            _ => sixthSource,
            _ => decimal.MinusOne);

        var actual = source.GetSixth();

        var actualValue = actual.Resolve();
        Assert.Equal(sixthSource, actualValue);
    }
}
