using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void WithThreeResolvers_SecondIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => SomeTextStructType);

            var thirdValue = PlusFifteenIdSomeStringNameRecord;
            var lastValue = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<IServiceProvider, string?>)null!,
                    _ => thirdValue,
                    _ => lastValue));
            
            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void WithThreeResolvers_ThirdIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => ZeroIdNullNameRecord);

            var secondValue = PlusFifteenIdRefType;
            var lastValue = LowerSomeString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => secondValue,
                    (Func<IServiceProvider, StructType>)null!,
                    _ => lastValue));
            
            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void WithThreeResolvers_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => MinusFifteenIdRefType);

            var secondValue = One;
            var thirdValue = LowerSomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => secondValue,
                    _ => thirdValue,
                    (Func<IServiceProvider, RecordType?>)null!));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithThreeResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType? lastValue)
        {
            var sourceValue = LowerSomeTextStructType;
            var source = Dependency.From(_ => sourceValue);
            
            var secondValue = MinusFifteenIdRefType;
            var thirdValue = DateTimeKind.Local;

            var actual = source.With(_ => secondValue, _ => thirdValue, _ => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceValue, secondValue, thirdValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}