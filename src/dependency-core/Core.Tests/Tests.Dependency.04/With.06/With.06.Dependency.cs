using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Fact]
        public void WithTwoDependency_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdRefType,
                _ => SomeTextStructType,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => MinusFifteen);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<DateTimeKind, RefType?>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(int.MinValue)]
        [InlineData(Zero)]
        [InlineData(PlusFifteen)]
        public void WithTwoDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            int? otherLast)
        {
            var firstSource = MinusFifteenIdRefType;
            var secondSource = LowerSomeTextStructType;

            var thirdSource = UpperSomeString;
            var fourthSource = MinusFifteenIdNullNameRecord;

            var source = Dependency.Create(
                _ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource);

            var otherFirst = PlusFifteenIdRefType;
            var other = Dependency.Create(_ => otherFirst, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, otherFirst, otherLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}