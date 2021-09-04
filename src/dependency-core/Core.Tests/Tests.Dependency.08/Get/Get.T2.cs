using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData(MixedWhiteSpacesString)]
        [InlineData(UpperSomeString)]
        public void GetSecond_ExpectResolvedValueIsEqualToSecondSource(
            string? secondSource)
        {
            var source = Dependency.Create(
                _ => LowerSomeTextStructType,
                _ => secondSource,
                _ => ZeroIdRefType,
                _ => PlusFifteen,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => new[] { decimal.MinValue, decimal.Zero, decimal.One },
                _ => (MinusOne, EmptyString, false),
                _ => new { Name = SomeString });

            var actual = source.GetSecond();
            var actualValue = actual.Resolve();

            Assert.Equal(secondSource, actualValue);
        }
    }
}