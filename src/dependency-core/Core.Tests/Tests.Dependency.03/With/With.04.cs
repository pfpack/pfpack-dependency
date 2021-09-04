using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Fact]
        public void WithOne_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => ZeroIdRefType, _ => PlusFifteenIdRefType, _ => LowerSomeTextStructType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With((Dependency<RecordType?>)null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithOne_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType? otherValue)
        {
            var firstSource = LowerSomeTextStructType;
            var secondSource = decimal.MinusOne;
            var thirdSource = MinusFifteenIdNullNameRecord;

            var source = Dependency.Create(_ => firstSource, _ => secondSource, _ => thirdSource);
            var other = Dependency.Create(_ => otherValue);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, otherValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}