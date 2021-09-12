using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void WithOneResolver_ThirdIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => MinusFifteenIdSomeStringNameRecord, _ => LowerSomeTextStructType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With((Func<IServiceProvider, RefType?>)null!));
            
            Assert.Equal("third", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(MinusFifteen)]
        [InlineData(int.MaxValue)]
        public void WithOneResolver_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            int? thirdValue)
        {
            var firstSource = ZeroIdNullNameRecord;
            var secondSource = MinusFifteenIdRefType;

            var source = Dependency.From(_ => firstSource, _ => secondSource);

            var actual = source.With(_ => thirdValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}