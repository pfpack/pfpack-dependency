#nullable enable

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
        public void ToFifth_ExpectResolvedValueIsEqualToFifthSource(
            string? fifthSource)
        {
            var source = Dependency.Create(
                _ => false,
                _ => decimal.MaxValue,
                _ => MinusFifteenIdRefType,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => fifthSource,
                _ => byte.MaxValue,
                _ => LowerSomeTextStructType);

            var actual = source.ToFifth();

            var actualValue = actual.Resolve();
            Assert.Equal(fifthSource, actualValue);
        }
    }
}