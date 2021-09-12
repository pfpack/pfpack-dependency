using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Fact]
        public void WithTwoResolvers_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => MinusFifteenIdRefType, _ => PlusFifteenIdSomeStringNameRecord, _ => EmptyString);

            var fifthValue = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<IServiceProvider, DateTime>)null!,
                    _ => fifthValue));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void WithTwoResolvers_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => ZeroIdNullNameRecord, _ => LowerSomeTextStructType, _ => false);

            var fourthValue = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => fourthValue,
                    (Func<IServiceProvider, object?>)null!));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(WhiteSpaceString)]
        [InlineData(UpperSomeString)]
        public void WithTwoResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            string lastValue)
        {
            var firstSource = PlusFifteenIdLowerSomeStringNameRecord;
            var secondSource = byte.MaxValue;

            var thirdSource = MinusFifteenIdRefType;
            var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource);

            var fourthValue = SomeTextStructType;

            var actual = source.With(_ => fourthValue, _ => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}