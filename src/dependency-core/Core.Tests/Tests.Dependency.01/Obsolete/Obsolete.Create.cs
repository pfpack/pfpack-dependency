using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Tests;

partial class OneDependencyTest
{
    [Fact]
    public void Obsolete_Create_ExpectMethodIsObsolete()
    {
        var type = typeof(Dependency<StructType>);
        var methodName = nameof(Dependency<StructType>.Create);

        var methodTypes = new[]
        {
                typeof(Func<IServiceProvider, StructType>)
            };

        var method = type.GetPublicStaticMethodOrThrow(methodName, 0, methodTypes);
        var obsoleteAttribute = method.GetObsoleteAttributeOrThrow();

        Assert.False(obsoleteAttribute.IsError);

        var expectedNewMethodName = nameof(Dependency<StructType>.From);
        Assert.Contains(expectedNewMethodName, obsoleteAttribute.Message, StringComparison.InvariantCulture);
    }

    [Obsolete(ObsoleteMessage.TestMethodObsolete)]
    [Fact]
    public void Obsolete_Create_SingleIsNull_ExpectArgumentNullException()
    {
        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<RefType?>.Create(
                (Func<IServiceProvider, RefType?>)null!));

        Assert.Equal("single", ex.ParamName);
    }

    [Obsolete(ObsoleteMessage.TestMethodObsolete)]
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