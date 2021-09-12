using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData(MinusFifteen)]
        [InlineData(One)]
        public void GetFourth_ExpectResolvedValueIsEqualToFourthSource(
            int? fourthSource)
        {
            var source = Dependency.From(
                _ => Zero,
                _ => PlusFifteenIdRefType,
                _ => new { Name = SomeString, Id = PlusFifteen },
                _ => fourthSource,
                _ => LowerSomeTextStructType,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => false,
                _ => (long.MaxValue, EmptyString, byte.MinValue));

            var actual = source.GetFourth();
            var actualValue = actual.Resolve();

            Assert.Equal(fourthSource, actualValue);
        }
    }
}