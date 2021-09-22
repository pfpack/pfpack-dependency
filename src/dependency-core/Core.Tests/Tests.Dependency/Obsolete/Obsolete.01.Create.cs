using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void Obsolete_Create_01_ExpectMethodIsObsolete()
        {
            var type = typeof(Dependency);
            var methodName = nameof(Dependency.Create);

            var method = type.GetPublicStaticMethodOrThrow(methodName, 1);
            var obsoleteAttribute = method.GetObsoleteAttributeOrThrow();

            Assert.False(obsoleteAttribute.IsError);

            var expectedNewMethodName = nameof(Dependency.From);
            Assert.Contains(expectedNewMethodName, obsoleteAttribute.Message, StringComparison.InvariantCulture);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_01_SingleIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(NullStructResolver));

            Assert.Equal("single", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void Obsolete_Create_01_SingleResolverIsNotNull_ExpectResolvedValueIsEqualToSource(
            RefType? sourceSingle)
        {
            var actual = Dependency.Create(_ => sourceSingle);
            var actualValue = actual.Resolve();

            Assert.Equal(sourceSingle, actualValue);
        }
    }
}