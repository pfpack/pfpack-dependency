using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void CreateFromFactory_01_SingleIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(NullRefFactory));

            Assert.Equal("single", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void CreateFromFactory_01_SingleIsNotNull_ExpectResolvedValueIsEqualToSource(
            RecordType sourceSingle)
        {
            var actual = Dependency.Create(() => sourceSingle);
            var actualValue = actual.Resolve();

            Assert.Equal(sourceSingle, actualValue);
        }
    }
}