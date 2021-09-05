using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Fact]
        public void WithThreeDependency_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => SomeTextStructType, _ => PlusFifteenIdLowerSomeStringNameRecord, _ => MinusFifteen);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<long?, RefType, DateTimeOffset>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithThreeDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType otherLast)
        {
            var firstSource = SomeString;
            var secondSource = MinusFifteenIdNullNameRecord;

            var thirdSource = PlusFifteenIdRefType;
            var source = Dependency.Create(_ => firstSource, _ => secondSource, _ => thirdSource);

            var otherFirst = decimal.MaxValue;
            var otherSecond = long.MaxValue;

            var other = Dependency.Create(_ => otherFirst, _ => otherSecond, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, otherFirst, otherSecond, otherLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}