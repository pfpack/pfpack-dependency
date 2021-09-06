using Xunit;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void GetEmpty_ExpectResolvedValueIsUnit()
        {
            var actual = Dependency.Empty;
            var actualValue = actual.Resolve();

            Assert.Equal(Unit.Value, actualValue);
        }

        [Fact]
        public void GetEmptyTwoTimes_ExpectDependenciesAreSame()
        {
            var firstDependency = Dependency.Empty;
            var secondDependency = Dependency.Empty;

            Assert.Same(firstDependency, secondDependency);
        }
    }
}