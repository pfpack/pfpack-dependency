#nullable enable

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
        public void ToFourth_ExpectResolvedValueIsEqualToFourthSource(
            int? fourthSource)
        {
            var source = Dependency.Create(
                _ => Zero,
                _ => PlusFifteenIdRefType,
                _ => new { Name = SomeString, Id = PlusFifteen },
                _ => fourthSource,
                _ => LowerSomeTextStructType,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => false,
                _ => (long.MaxValue, EmptyString, byte.MinValue));

            var actual = source.ToFourth();
            var actualValue = actual.Resolve();

            Assert.Equal(fourthSource, actualValue);
        }
    }
}