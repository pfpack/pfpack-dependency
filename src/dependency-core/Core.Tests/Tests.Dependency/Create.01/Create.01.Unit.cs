using Xunit;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void Create_01_Unit_ExpectResolvedValueIsUnit()
        {
            var actual = Dependency.Create();
            var actualValue = actual.Resolve();

            Assert.Equal(Unit.Value, actualValue);
        }
    }
}