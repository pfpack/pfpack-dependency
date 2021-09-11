using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void Of_ExpectResolvedValuesAreEqualToSource(
            RecordType? sourceFifth)
        {
            var sourceFirst = decimal.MinusOne;
            var sourceSecond = PlusFifteenIdLowerSomeStringNameRecord;
            var sourceThird = LowerSomeTextStructType;
            var sourceFourth = new object();

            var actual = Dependency<decimal?, RecordType, StructType, object?, RecordType?>.Of(
                sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}