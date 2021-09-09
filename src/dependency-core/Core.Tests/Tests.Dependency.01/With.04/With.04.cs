using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithThree_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType lastValue)
        {
            var sourceValue = PlusFifteenIdLowerSomeStringNameRecord;
            var source = Dependency.Create(_ => sourceValue);
            
            var secondValue = long.MinValue;
            var thirdValue = LowerSomeTextStructType;

            var actual = source.With(secondValue, thirdValue, lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceValue, secondValue, thirdValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}