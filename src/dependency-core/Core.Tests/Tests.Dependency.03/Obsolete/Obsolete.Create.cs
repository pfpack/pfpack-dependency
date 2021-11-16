using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class ThreeDependencyTest
{
    [Fact]
    public void Obsolete_Create_ExpectMethodIsObsolete()
    {
        var type = typeof(Dependency<int?, StructType, RecordType>);
        var methodName = nameof(Dependency<int?, StructType, RecordType>.Create);

        var methodTypes = new[]
        {
                typeof(Func<IServiceProvider, int?>),
                typeof(Func<IServiceProvider, StructType>),
                typeof(Func<IServiceProvider, RecordType>)
            };

        var method = type.GetPublicStaticMethodOrThrow(methodName, 0, methodTypes);
        var obsoleteAttribute = method.GetObsoleteAttributeOrThrow();

        Assert.False(obsoleteAttribute.IsError);

        var expectedNewMethodName = nameof(Dependency<int?, StructType, RecordType>.From);
        Assert.Contains(expectedNewMethodName, obsoleteAttribute.Message, StringComparison.InvariantCulture);
    }

    [Obsolete(ObsoleteMessage.TestMethodObsolete)]
    [Fact]
    public void Obsolete_Create_FirstIsNull_ExpectArgumentNullException()
    {
        var second = MinusFifteenIdNullNameRecord;
        var third = ZeroIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<int, RecordType?, RefType>.Create(
                null!,
                _ => second,
                _ => third));

        Assert.Equal("first", ex.ParamName);
    }

    [Obsolete(ObsoleteMessage.TestMethodObsolete)]
    [Fact]
    public void Obsolete_Create_SecondIsNull_ExpectArgumentNullException()
    {
        var first = default(StructType);
        var third = UpperSomeString;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<StructType, RefType?, string?>.Create(
                _ => first,
                null!,
                _ => third));

        Assert.Equal("second", ex.ParamName);
    }

    [Obsolete(ObsoleteMessage.TestMethodObsolete)]
    [Fact]
    public void Obsolete_Create_ThirdIsNull_ExpectArgumentNullException()
    {
        var first = PlusFifteenIdRefType;
        var second = default(RecordType);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<RefType?, RecordType?, StructType?>.Create(
                _ => first,
                _ => second,
                null!));

        Assert.Equal("third", ex.ParamName);
    }

    [Obsolete(ObsoleteMessage.TestMethodObsolete)]
    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void Obsolete_Create_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
        RecordType sourceThird)
    {
        var sourceFirst = MinusOne;
        var sourceSecond = LowerSomeTextStructType;

        var actual = Dependency<int?, StructType, RecordType>.Create(
            _ => sourceFirst,
            _ => sourceSecond,
            _ => sourceThird);

        var actualValue = actual.Resolve();

        var expectedValue = (sourceFirst, sourceSecond, sourceThird);
        Assert.Equal(expectedValue, actualValue);
    }
}