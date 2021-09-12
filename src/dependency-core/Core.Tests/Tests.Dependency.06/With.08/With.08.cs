using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithTwo_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType? restValue)
        {
            var firstSource = decimal.MaxValue;
            var secondSource = false;
            var thirdSource = LowerSomeTextStructType;
            var fourthSource = long.MinValue;
            var fifthSource = PlusFifteenIdRefType;
            var sixthSource = new object();

            var source = Dependency.From(
                _ => firstSource,
                _ => secondSource,
                _ => thirdSource,
                _ => fourthSource,
                _ => fifthSource,
                _ => sixthSource);
            
            var seventhValue = DateTimeKind.Utc;

            var actual = source.With(seventhValue, restValue);
            var actualValue = actual.Resolve();

            var expectedValue = ((firstSource, secondSource, thirdSource, fourthSource), (fifthSource, sixthSource, seventhValue, restValue));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}