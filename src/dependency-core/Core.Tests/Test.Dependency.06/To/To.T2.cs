#nullable enable

using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(TabString)]
        [InlineData(LowerSomeString)]
        [InlineData(SomeString)]
        public void ToSecond_ExpectResolvedValueIsEqualToSecondSource(
            string? secondSource)
        {
            var source = Dependency.Create(
                _ => SomeTextStructType,
                _ => secondSource,
                _ => MinusFifteenIdRefType,
                _ => PlusFifteen,
                _ => ZeroIdNullNameRecord,
                _ => long.MaxValue);

            var actual = source.ToSecond();
            var actualValue = actual.Resolve();

            Assert.Equal(secondSource, actualValue);
        }
    }
}