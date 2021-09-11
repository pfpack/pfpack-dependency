using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void Obsolete_Create_ExpectMethodIsObsolete()
        {
            var type = typeof(Dependency<>);
            var methodName = nameof(Dependency<StructType>.Create);

            var obsoleteAttribute = ReflectionAssert.IsStaticMethodObsolete(type, methodName);

            Assert.False(obsoleteAttribute.IsError);

            var expectedInsteadMethodName = "Dependency<T>.From";
            Assert.Contains(expectedInsteadMethodName, obsoleteAttribute.Message, StringComparison.InvariantCultureIgnoreCase);
        }

        [Obsolete]
        [Fact]
        public void Obsolete_Create_SingleIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RefType?>.Create(
                    (Func<IServiceProvider, RefType?>)null!));

            Assert.Equal("single", ex.ParamName);
        }

        [Obsolete]
        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void Obsolete_Create_SingleIsNotNull_ExpectResolvedValueIsEqualToSource(
            StructType sourceSingle)
        {
            var actual = Dependency<StructType>.Create(
                _ => sourceSingle);

            var actualValue = actual.Resolve();

            var expectedValue = sourceSingle;
            Assert.Equal(expectedValue, actualValue);
        }
    }
}