using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData(WhiteSpaceString)]
        [InlineData(SomeString)]
        public void GetFifth_ExpectResolvedValueIsEqualToFifthSource(
            string? fifthSource)
        {
            var source = Dependency.From(
                _ => false,
                _ => decimal.MaxValue,
                _ => MinusFifteenIdRefType,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => fifthSource,
                _ => byte.MaxValue,
                _ => LowerSomeTextStructType);

            var actual = source.GetFifth();

            var actualValue = actual.Resolve();
            Assert.Equal(fifthSource, actualValue);
        }
    }
}