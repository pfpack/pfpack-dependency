using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void Of_07_ExpectResolvedValuesAreEqualToSource(
            RecordType sourceSeventh)
        {
            var sourceFirst = (long.MinValue, EmptyString);
            var sourceSecond = SomeTextStructType;
            var sourceThird = byte.MaxValue;
            var sourceFourth = true;
            var sourceFifth = ZeroIdRefType;
            var sourceSixth = Array.Empty<DateTimeOffset>();

            var actual = Dependency.Of(
                sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth, sourceSixth, sourceSeventh);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth, sourceSixth, sourceSeventh);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}