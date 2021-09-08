using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void WithTwoFactories_ThirdIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => PlusFifteenIdSomeStringNameRecord, _ => long.MinValue);
            var lastValue = LowerSomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<RefType?>)null!,
                    () => lastValue));
            
            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void WithTwoFactories_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => decimal.MaxValue, _ => PlusFifteenIdRefType);
            var thirdValue = ZeroIdNullNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => thirdValue,
                    (Func<StructType>)null!));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithTwoFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType? lastValue)
        {
            var firstSource = new { Value = long.MaxValue };
            var secondSource = MinusFifteenIdRefType;

            var source = Dependency.Create(_ => firstSource, _ => secondSource);
            var thirdValue = SomeTextStructType;

            var actual = source.With(() => thirdValue, () => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}