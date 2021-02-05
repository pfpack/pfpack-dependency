#nullable enable

using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void ToFirst_ExpectResolvedValueAreSameAsFirstSource(
            RefType? firstSource)
        {
            var source = Dependency.Create(_ => firstSource, _ => SomeString);
            var actual = source.ToFirst();

            var actualValue = actual.Resolve();
            Assert.Equal(firstSource, actualValue);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void ToSecond_ExpectResolvedValueAreSameAsSecondSource(
            StructType secondSource)
        {
            var source = Dependency.Create(_ => MinusFifteen, _ => secondSource);
            var actual = source.ToSecond();

            var actualValue = actual.Resolve();
            Assert.Equal(secondSource, actualValue);
        }
    }
}