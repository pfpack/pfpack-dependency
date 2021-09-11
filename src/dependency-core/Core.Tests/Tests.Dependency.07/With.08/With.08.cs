using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void WithOne_ExpectResolvedValuesAreEqualToSourceAndOther(
            StructType restValue)
        {
            var firstSource = PlusFifteenIdLowerSomeStringNameRecord;
            var secondSource = new object();

            var thirdSource = EmptyString;
            var fourthSource = false;

            var fifthSource = long.MinValue;
            var sixthSource = DateTimeKind.Unspecified;

            var seventhSource = MinusFifteenIdRefType;

            var source = Dependency.From(
                _ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource, _ => sixthSource, _ => seventhSource);

            var actual = source.With(restValue);
            var actualValue = actual.Resolve();

            var expectedValue = ((firstSource, secondSource, thirdSource, fourthSource), (fifthSource, sixthSource, seventhSource, restValue));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}