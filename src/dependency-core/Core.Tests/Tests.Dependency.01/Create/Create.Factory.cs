using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void CreateFromFactory_SingleIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<StructType?>.Create(
                    (Func<StructType?>)null!));

            Assert.Equal("single", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(SomeString)]
        public void CreateFromFactory_SingleIsNotNull_ExpectResolvedValueIsEqualToSource(
            string? sourceSingle)
        {
            var actual = Dependency<string?>.Create(
                () => sourceSingle);

            var actualValue = actual.Resolve();

            var expectedValue = sourceSingle;
            Assert.Equal(expectedValue, actualValue);
        }
    }
}