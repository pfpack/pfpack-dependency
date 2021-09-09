using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void Of_ExpectResolvedValuesAreEqualToSource(
            RefType? sourceThird)
        {
            var sourceFirst = SomeTextStructType;
            var sourceSecond = ZeroIdNullNameRecord;

            var actual = Dependency<StructType, RecordType, RefType?>.Of(
                sourceFirst, sourceSecond, sourceThird);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}