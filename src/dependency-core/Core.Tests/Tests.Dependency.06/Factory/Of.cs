using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class SixDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void Of_ExpectResolvedValuesAreEqualToSource(
        StructType sourceSixth)
    {
        var sourceFirst = PlusFifteenIdSomeStringNameRecord;
        var sourceSecond = MixedWhiteSpacesString;
        var sourceThird = long.MaxValue;
        var sourceFourth = default(RefType);
        var sourceFifth = new object();

        var actual = Dependency<RecordType, string?, long?, RefType?, object, StructType>.Of(
            sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth, sourceSixth);

        var actualValue = actual.Resolve();

        var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth, sourceSixth);
        Assert.Equal(expectedValue, actualValue);
    }
}
