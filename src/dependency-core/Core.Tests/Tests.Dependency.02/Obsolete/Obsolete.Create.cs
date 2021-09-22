using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void Obsolete_Create_ExpectMethodIsObsolete()
        {
            var type = typeof(Dependency<object, RefType?>);
            var methodName = nameof(Dependency<object, RefType?>.Create);

            var methodTypes = new[]
            {
                typeof(Func<IServiceProvider, object>),
                typeof(Func<IServiceProvider, RefType?>)
            };

            var method = type.GetPublicStaticMethodOrThrow(methodName, 0, methodTypes);
            var obsoleteAttribute = method.GetObsoleteAttributeOrThrow();

            Assert.False(obsoleteAttribute.IsError);

            var expectedNewMethodName = nameof(Dependency<object, RefType?>.From);
            Assert.Contains(expectedNewMethodName, obsoleteAttribute.Message, StringComparison.InvariantCulture);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_FirstIsNull_ExpectArgumentNullException()
        {
            var second = ZeroIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<StructType, RefType>.Create(
                    null!,
                    _ => second));

            Assert.Equal("first", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_SecondIsNull_ExpectArgumentNullException()
        {
            var first = SomeString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<string?, RecordType>.Create(
                    _ => first,
                    null!));

            Assert.Equal("second", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void Obsolete_Create_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
            RefType? sourceSecond)
        {
            var sourceFirst = new { Name = SomeString };

            var actual = Dependency<object, RefType?>.Create(
                _ => sourceFirst,
                _ => sourceSecond);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}