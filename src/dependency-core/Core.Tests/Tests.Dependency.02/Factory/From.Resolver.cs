using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class TwoDependencyTest
{
    [Fact]
    public void From_Resolver_FirstIsNull_ExpectArgumentNullException()
    {
        var second = ZeroIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<StructType, RefType>.From(
                null!,
                _ => second));

        Assert.Equal("first", ex.ParamName);
    }

    [Fact]
    public void From_Resolver_SecondIsNull_ExpectArgumentNullException()
    {
        var first = SomeString;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<string?, RecordType>.From(
                _ => first,
                null!));

        Assert.Equal("second", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void From_Resolver_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
        RefType? sourceSecond)
    {
        var sourceFirst = new { Name = SomeString };

        var actual = Dependency<object, RefType?>.From(
            _ => sourceFirst,
            _ => sourceSecond);

        var actualValue = actual.Resolve();

        var expectedValue = (sourceFirst, sourceSecond);
        Assert.Equal(expectedValue, actualValue);
    }
}