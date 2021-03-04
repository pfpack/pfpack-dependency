#nullable enable

using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void ToSecond_ExpectResolvedValueIsEqualToSecondSource(
            RefType secondSource)
        {
            var source = Dependency.Create(_ => SomeString, _ => secondSource, _ => new object());
            var actual = source.ToSecond();

            var actualValue = actual.Resolve();
            Assert.Equal(secondSource, actualValue);
        }
    }
}