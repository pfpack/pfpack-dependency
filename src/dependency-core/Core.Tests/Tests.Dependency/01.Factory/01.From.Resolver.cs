using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void From_Resolver_01_SingleIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(NullStructResolver));

            Assert.Equal("single", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void From_Resolver_01_SingleResolverIsNotNull_ExpectResolvedValueIsEqualToSource(
            RefType? sourceSingle)
        {
            var actual = Dependency.From(_ => sourceSingle);
            var actualValue = actual.Resolve();

            Assert.Equal(sourceSingle, actualValue);
        }
    }
}