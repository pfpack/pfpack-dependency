using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void WithSeven_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => MinusFifteenIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<object?, DateTimeOffset, StructType, decimal?, RecordType, RefType, string>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(MinusFifteen)]
        [InlineData(int.MaxValue)]
        public void WithSeven_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            int? otherLast)
        {
            var sourceValue = new { Value = decimal.MaxValue };
            var source = Dependency.Create(_ => sourceValue);
            
            var otherFirst = new[] { int.MinValue, MinusOne, PlusFifteen };
            var otherSecond = DateTimeKind.Local;

            var otherThird = TwoWhiteSpacesString;
            var otherFourth = PlusFifteenIdRefType;

            var otherFifth = false;
            var otherSixth = MinusFifteenIdSomeStringNameRecord;

            var other = Dependency.Create(
                _ => otherFirst, _ => otherSecond, _ => otherThird, _ => otherFourth, _ => otherFifth, _ => otherSixth, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = ((sourceValue, otherFirst, otherSecond, otherThird), (otherFourth, otherFifth, otherSixth, otherLast));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}