using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void GetSecond_ExpectResolvedValueIsEqualToSecondSource(
            RefType secondSource)
        {
            var source = Dependency.From(_ => SomeString, _ => secondSource, _ => new object());
            var actual = source.GetSecond();

            var actualValue = actual.Resolve();
            Assert.Equal(secondSource, actualValue);
        }
    }
}