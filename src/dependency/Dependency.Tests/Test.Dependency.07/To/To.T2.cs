#nullable enable

using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void ToSecond_ExpectResolvedValueIsEqualToSecondSource(
            StructType secondSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteen,
                _ => secondSource,
                _ => ZeroIdNullNameRecord,
                _ => SomeString,
                _ => new { Amount = decimal.One },
                _ => false,
                _ => PlusFifteenIdRefType);

            var actual = source.ToSecond();
            var actualValue = actual.Resolve();

            Assert.Equal(secondSource, actualValue);
        }
    }
}