using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithOne_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType sixthValue)
        {
            var firstSource = new object();
            var secondSource = int.MinValue;

            var thirdSource = SomeTextStructType;
            var fourthSource = PlusFifteenIdSomeStringNameRecord;

            var fifthSource = long.MaxValue;

            var source = Dependency.Create(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource);

            var actual = source.With(sixthValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthSource, sixthValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}