using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithThree_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType lastValue)
        {
            var firstSource = PlusFifteenIdRefType;
            var secondSource = decimal.MinusOne;

            var thirdSource = long.MaxValue;
            var fourthSource = false;

            var fifthSource = new { Id = One };

            var source = Dependency.Create(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource);

            var sixthValue = SomeTextStructType;
            var seventhValue = DateTimeKind.Local;

            var actual = source.With(sixthValue, seventhValue, lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = ((firstSource, secondSource, thirdSource, fourthSource), (fifthSource, sixthValue, seventhValue, lastValue));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}