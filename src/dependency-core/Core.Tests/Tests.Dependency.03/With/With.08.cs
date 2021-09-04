using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Fact]
        public void WithFive_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => new object(), _ => MinusFifteenIdSomeStringNameRecord, _ => PlusFifteen);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<decimal, RefType, string?, StructType?, DateTime>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(MinusOne)]
        [InlineData(PlusFifteen)]
        public void WithFive_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            int? otherLast)
        {
            var firstSource = MinusFifteenIdRefType;
            var secondSource = SomeTextStructType;
            
            var thirdSource = EmptyString;
            var source = Dependency.Create(_ => firstSource, _ => secondSource, _ => thirdSource);
            
            var otherFirst = Array.Empty<DateTime>();
            var otherSecond = PlusFifteenIdLowerSomeStringNameRecord;

            var otherThird = true;
            var otherFourth = new { Name = UpperSomeString };

            var other = Dependency.Create(_ => otherFirst, _ => otherSecond, _ => otherThird, _ => otherFourth, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = ((firstSource, secondSource, thirdSource, otherFirst), (otherSecond, otherThird, otherFourth, otherLast));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}