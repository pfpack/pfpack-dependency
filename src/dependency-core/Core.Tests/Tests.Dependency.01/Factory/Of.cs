using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Tests;

partial class OneDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void Of_ExpectResolvedValueIsEqualToSource(
        RecordType? sourceSingle)
    {
        var actual = Dependency<RecordType?>.Of(
            sourceSingle);

        var actualValue = actual.Resolve();

        var expectedValue = sourceSingle;
        Assert.Equal(expectedValue, actualValue);
    }
}