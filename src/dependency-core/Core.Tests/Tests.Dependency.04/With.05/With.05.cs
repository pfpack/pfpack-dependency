using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithOne_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType? fifthValue)
        {
            var firstSource = MinusFifteenIdRefType;
            var secondSource = LowerSomeTextStructType;

            var thirdSource = new object();
            var fourthSource = DateTimeKind.Unspecified;

            var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource);

            var actual = source.With(fifthValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}