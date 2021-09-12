using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Fact]
        public void WithFourDependency_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => PlusFifteen,
                _ => MinusFifteenIdNullNameRecord,
                _ => EmptyString,
                _ => LowerSomeTextStructType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<long?, DateTime, RefType, DateTimeKind?>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithFourDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType otherLast)
        {
            var firstSource = byte.MaxValue;
            var secondSource = false;

            var thirdSource = MinusFifteenIdRefType;
            var fourthSource = new { Value = decimal.One };

            var source = Dependency.From(
                _ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource);

            var otherFirst = SomeTextStructType;
            var otherSecond = One;

            var otherThird = new[] { int.MinValue, Zero, PlusFifteen };
            var other = Dependency.From(_ => otherFirst, _ => otherSecond, _ => otherThird, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = ((firstSource, secondSource, thirdSource, fourthSource), (otherFirst, otherSecond, otherThird, otherLast));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}