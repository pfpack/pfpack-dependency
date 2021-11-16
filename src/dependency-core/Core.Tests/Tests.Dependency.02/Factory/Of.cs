using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class TwoDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void Of_ExpectResolvedValuesAreEqualToSource(
        RecordType sourceSecond)
    {
        var sourceFirst = LowerSomeTextStructType;

        var actual = Dependency<StructType?, RecordType>.Of(
            sourceFirst, sourceSecond);

        var actualValue = actual.Resolve();

        var expectedValue = (sourceFirst, sourceSecond);
        Assert.Equal(expectedValue, actualValue);
    }
}