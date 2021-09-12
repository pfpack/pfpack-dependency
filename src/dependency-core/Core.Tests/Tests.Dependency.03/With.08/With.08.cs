using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithFive_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType? lastValue)
        {
            var firstSource = DateTimeKind.Local;
            var secondSource = byte.MaxValue;

            var thirdSource = MinusFifteenIdRefType;
            var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource);

            var fourthValue = SomeTextStructType;
            var fifthValue = new object();

            var sixthValue = true;
            var seventhValue = ThreeWhiteSpacesString;

            var actual = source.With(fourthValue, fifthValue, sixthValue, seventhValue, lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = ((firstSource, secondSource, thirdSource, fourthValue), (fifthValue, sixthValue, seventhValue, lastValue));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}