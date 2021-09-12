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
        public void WithOne_ExpectResolvedValuesAreEqualToSourceAndOther(
            string thirdValue)
        {
            var firstSource = SomeTextStructType;
            var secondSource = PlusFifteenIdSomeStringNameRecord;

            var source = Dependency.From(_ => firstSource, _ => secondSource);

            var actual = source.With(thirdValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}