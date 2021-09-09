using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithTwo_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType lastValue)
        {
            var sourceValue = SomeTextStructType;
            var source = Dependency.Create(_ => sourceValue);
            
            var secondValue = ZeroIdRefType;

            var actual = source.With(secondValue, lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceValue, secondValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}