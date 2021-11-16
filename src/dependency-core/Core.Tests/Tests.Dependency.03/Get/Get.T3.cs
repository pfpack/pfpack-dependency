using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class ThreeDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void GetThird_ExpectResolvedValueIsEqualToThirdSource(
        RecordType thirdSource)
    {
        var source = Dependency.From(_ => LowerSomeTextStructType, _ => PlusFifteenIdRefType, _ => thirdSource);
        var actual = source.GetThird();

        var actualValue = actual.Resolve();
        Assert.Equal(thirdSource, actualValue);
    }
}