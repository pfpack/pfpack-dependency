using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Fact]
        public void WithThree_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => new object(),
                _ => PlusFifteenIdRefType,
                _ => MinusFifteenIdNullNameRecord,
                _ => LowerSomeTextStructType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<string?, decimal?, byte>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithThree_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType? otherLast)
        {
            var firstSource = PlusFifteenIdSomeStringNameRecord;
            var secondSource = SomeString;

            var thirdSource = decimal.MinValue;
            var fourthSource = UpperSomeString;

            var source = Dependency.Create(
                _ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource);

            var otherFirst = SomeTextStructType;
            var otherSecond = byte.MaxValue;

            var other = Dependency.Create(_ => otherFirst, _ => otherSecond, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, otherFirst, otherSecond, otherLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}