using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void Of_ExpectResolvedValuesAreEqualToSource(
            RefType? sourceRest)
        {
            var sourceFirst = byte.MaxValue;
            var sourceSecond = PlusFifteenIdLowerSomeStringNameRecord;
            var sourceThird = new object();
            var sourceFourth = DateTimeKind.Utc;
            var sourceFifth = LowerSomeTextStructType;
            var sourceSixth = decimal.MaxValue;
            var sourceSeventh = ThreeWhiteSpacesString;

            var actual = Dependency<byte?, RecordType, object, DateTimeKind, StructType?, decimal, string?, RefType?>.Of(
                sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth, sourceSixth, sourceSeventh, sourceRest);

            var actualValue = actual.Resolve();

            var expectedValue = ((sourceFirst, sourceSecond, sourceThird, sourceFourth), (sourceFifth, sourceSixth, sourceSeventh, sourceRest));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}