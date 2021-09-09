using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(SomeString)]
        public void WithFour_ExpectResolvedValuesAreEqualToSourceAndOther(
            string? lastValue)
        {
            var sourceValue = decimal.MaxValue;
            var source = Dependency.Create(_ => sourceValue);
            
            var secondValue = MinusFifteenIdRefType;
            var thirdValue = SomeTextStructType;

            var fourthValue = ZeroIdNullNameRecord;

            var actual = source.With(secondValue, thirdValue, fourthValue, lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceValue, secondValue, thirdValue, fourthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}