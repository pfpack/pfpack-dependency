using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FourDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void Of_ExpectResolvedValuesAreEqualToSource(
        StructType sourceFourth)
    {
        var sourceFirst = default(RecordType);
        var sourceSecond = MixedWhiteSpacesString;
        var sourceThird = MinusFifteenIdRefType;

        var actual = Dependency<RecordType?, string?, RefType, StructType>.Of(
            sourceFirst, sourceSecond, sourceThird, sourceFourth);

        var actualValue = actual.Resolve();

        var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth);
        Assert.Equal(expectedValue, actualValue);
    }
}