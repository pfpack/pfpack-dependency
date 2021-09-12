using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void From_Resolver_SingleIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RefType?>.From(
                    (Func<IServiceProvider, RefType?>)null!));

            Assert.Equal("single", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void From_Resolver_SingleIsNotNull_ExpectResolvedValueIsEqualToSource(
            StructType sourceSingle)
        {
            var actual = Dependency<StructType>.From(
                _ => sourceSingle);

            var actualValue = actual.Resolve();

            var expectedValue = sourceSingle;
            Assert.Equal(expectedValue, actualValue);
        }
    }
}