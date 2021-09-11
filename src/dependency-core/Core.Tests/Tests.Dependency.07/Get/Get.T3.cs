using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData(false)]
        [InlineData(true)]
        public void GetThird_ExpectResolvedValueIsEqualToThirdSource(
            bool? thirdSource)
        {
            var source = Dependency.From(
                _ => LowerSomeTextStructType,
                _ => new object(),
                _ => thirdSource,
                _ => MinusFifteen,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => decimal.MinValue,
                _ => MinusFifteenIdRefType);

            var actual = source.GetThird();

            var actualValue = actual.Resolve();
            Assert.Equal(thirdSource, actualValue);
        }
    }
}