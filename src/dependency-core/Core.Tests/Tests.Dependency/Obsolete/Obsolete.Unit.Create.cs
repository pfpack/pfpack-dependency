using Xunit;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void Obsolete_Create_ExpectMethodIsObsolete()
        {
            var type = typeof(Dependency);
            var methodName = nameof(Dependency.Create);

            var method = type.GetPublicStaticMethodOrThrow(methodName, 0);
            var obsoleteAttribute = method.GetObsoleteAttributeOrThrow();

            Assert.False(obsoleteAttribute.IsError);

            var expectedInsteadMethodName = $"{nameof(Dependency)}.{nameof(Dependency.Empty)}";
            Assert.Contains(expectedInsteadMethodName, obsoleteAttribute.Message, StringComparison.InvariantCultureIgnoreCase);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_Unit_ExpectResolvedValueIsUnit()
        {
            var actual = Dependency.Create();
            var actualValue = actual.Resolve();

            Assert.Equal(Unit.Value, actualValue);
        }
    }
}