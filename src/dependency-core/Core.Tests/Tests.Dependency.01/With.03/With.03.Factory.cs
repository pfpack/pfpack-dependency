using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void WithTwoFactories_SecondIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => SomeTextStructType);
            var lastValue = PlusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<RecordType?>)null!,
                    () => lastValue));
            
            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void WithTwoFactories_ThirdIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => MinusFifteenIdRefType);
            var secondValue = ZeroIdNullNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => secondValue,
                    (Func<StructType>)null!));
            
            Assert.Equal("third", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithTwoFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType? lastValue)
        {
            var sourceValue = MinusFifteenIdSomeStringNameRecord;
            var source = Dependency.Create(_ => sourceValue);
            
            var secondValue = LowerSomeTextStructType;

            var actual = source.With(() => secondValue, () => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceValue, secondValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}