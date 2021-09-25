using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class ThreeDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void GetFirst_ExpectResolvedValueAreEqualToFirstSource(
        StructType firstSource)
    {
        var source = Dependency.From(_ => firstSource, _ => SomeString, _ => PlusFifteenIdRefType);
        var actual = source.GetFirst();

        var actualValue = actual.Resolve();
        Assert.Equal(firstSource, actualValue);
    }
}
