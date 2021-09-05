using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void WithThreeResolvers_ThirdIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => PlusFifteenIdRefType, _ => SomeTextStructType);

            var fourthValue = decimal.One;
            var lastValue = new object();

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<IServiceProvider, RecordType>)null!,
                    _ => fourthValue,
                    _ => lastValue));
            
            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void WithThreeResolvers_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => MinusOne, _ => PlusFifteenIdSomeStringNameRecord);

            var thirdValue = decimal.One;
            var lastValue = ZeroIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => thirdValue,
                    (Func<IServiceProvider, StructType?>)null!,
                    _ => lastValue));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void WithThreeResolvers_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => LowerSomeTextStructType, _ => MinusFifteenIdRefType);

            var thirdValue = PlusFifteenIdSomeStringNameRecord;
            var fourthValue = Zero;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => thirdValue,
                    _ => fourthValue,
                    (Func<IServiceProvider, object?>)null!));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithThreeResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType? lastValue)
        {
            var firstSource = MinusOne;
            var secondSource = LowerSomeTextStructType;

            var source = Dependency.Create(_ => firstSource, _ => secondSource);

            var thirdValue = MinusFifteenIdRefType;
            var fourthValue = DateTimeKind.Local;

            var actual = source.With(_ => thirdValue, _ => fourthValue, _ => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdValue, fourthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}