using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FourDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void GetFourth_ExpectResolvedValueIsEqualToFourthSource(
        RecordType? fourthSource)
    {
        var source = Dependency.From(
            _ => int.MaxValue, _ => ZeroIdRefType, _ => new object(), _ => fourthSource);

        var actual = source.GetFourth();

        var actualValue = actual.Resolve();
        Assert.Equal(fourthSource, actualValue);
    }
}
