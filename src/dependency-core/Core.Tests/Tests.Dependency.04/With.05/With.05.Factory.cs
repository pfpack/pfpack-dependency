using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Fact]
        public void WithOneFactory_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => new { Text = EmptyString },
                _ => decimal.One,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => LowerSomeTextStructType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With((Func<RefType>)null!));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(false)]
        [InlineData(true)]
        public void WithOneFactory_FifthIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            bool? fifthValue)
        {
            var firstSource = PlusFifteenIdSomeStringNameRecord;
            var secondSource = ZeroIdRefType;

            var thirdSource = MinusOne;
            var fourthSource = SomeTextStructType;

            var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource);

            var actual = source.With(() => fifthValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}