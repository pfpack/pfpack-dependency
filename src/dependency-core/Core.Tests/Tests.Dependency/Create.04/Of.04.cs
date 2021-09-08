using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void Of_04_ExpectResolvedValuesAreEqualToSource(
            RecordType sourceFourth)
        {
            var sourceFirst = PlusFifteenIdRefType;
            var sourceSecond = decimal.MaxValue;
            var sourceThird = SomeTextStructType;

            var actual = Dependency.Of(sourceFirst, sourceSecond, sourceThird, sourceFourth);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}