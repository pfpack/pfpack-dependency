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
        public void WithSix_ExpectResolvedValuesAreEqualToSourceAndOther(
            string? lastValue)
        {
            var firstSource = LowerSomeTextStructType;
            var secondSource = true;

            var source = Dependency.Create(_ => firstSource, _ => secondSource);

            var thirdValue = PlusFifteenIdSomeStringNameRecord;
            var fourthValue = new object();

            var fifthValue = decimal.MinusOne;
            var sixthValue = ZeroIdRefType;

            var seventhValue = DateTimeKind.Utc;

            var actual = source.With(thirdValue, fourthValue, fifthValue, sixthValue, seventhValue, lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = ((firstSource, secondSource, thirdValue, fourthValue), (fifthValue, sixthValue, seventhValue, lastValue));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}