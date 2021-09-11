using Xunit;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void Obsolete_Create_Unit_ExpectResolvedValueIsUnit()
        {
            var actual = Dependency.Create();
            var actualValue = actual.Resolve();

            Assert.Equal(Unit.Value, actualValue);
        }
    }
}