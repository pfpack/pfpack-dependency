using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithTwo_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType? lastValue)
        {
            var firstSource = MinusFifteenIdRefType;
            var secondSource = new object();

            var thirdSource = true;
            var fourthSource = TabString;

            var source = Dependency.Create(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource);

            var fifthValue = LowerSomeTextStructType;

            var actual = source.With(fifthValue, lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}