using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class SevenDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void GetFirst_ExpectResolvedValueIsEqualToFirstSource(
        RefType? firstSource)
    {
        var source = Dependency.From(
            _ => firstSource,
            _ => SomeTextStructType,
            _ => UpperSomeString,
            _ => byte.MaxValue,
            _ => MinusFifteenIdNullNameRecord,
            _ => decimal.One,
            _ => new object());

        var actual = source.GetFirst();
        var actualValue = actual.Resolve();

        Assert.Equal(firstSource, actualValue);
    }
}