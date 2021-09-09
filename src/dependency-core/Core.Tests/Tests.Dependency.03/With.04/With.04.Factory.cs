using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Fact]
        public void WithOneFactory_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => PlusFifteen, _ => ZeroIdNullNameRecord, _ => SomeTextStructType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With((Func<RefType?>)null!));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(SomeString)]
        public void WithOneFactory_FourthIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            string fourthValue)
        {
            var firstSource = LowerSomeTextStructType;
            var secondSource = MinusFifteenIdRefType;

            var thirdSource = PlusFifteenIdLowerSomeStringNameRecord;
            var source = Dependency.Create(_ => firstSource, _ => secondSource, _ => thirdSource);

            var actual = source.With(() => fourthValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}