using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class DependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void Of_05_ExpectResolvedValuesAreEqualToSource(
        RefType? sourceFifth)
    {
        var sourceFirst = true;
        var sourceSecond = PlusFifteenIdSomeStringNameRecord;
        var sourceThird = SomeTextStructType;
        var sourceFourth = MinusOne;

        var actual = Dependency.Of(
            sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth);

        var actualValue = actual.Resolve();

        var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth);
        Assert.Equal(expectedValue, actualValue);
    }
}