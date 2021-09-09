using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(SomeString)]
        public void WithTwo_ExpectResolvedValuesAreEqualToSourceAndOther(
            string? lastValue)
        {
            var firstSource = SomeTextStructType;
            var secondSource = MinusFifteenIdNullNameRecord;

            var source = Dependency.Create(_ => firstSource, _ => secondSource);
            var thirdValue = PlusFifteenIdRefType;

            var actual = source.With(thirdValue, lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}