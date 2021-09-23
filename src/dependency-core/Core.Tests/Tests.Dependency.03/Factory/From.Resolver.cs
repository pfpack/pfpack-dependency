using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class ThreeDependencyTest
{
    [Fact]
    public void From_Resolver_FirstIsNull_ExpectArgumentNullException()
    {
        var second = MinusFifteenIdNullNameRecord;
        var third = ZeroIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<int, RecordType?, RefType>.From(
                null!,
                _ => second,
                _ => third));

        Assert.Equal("first", ex.ParamName);
    }

    [Fact]
    public void From_Resolver_SecondIsNull_ExpectArgumentNullException()
    {
        var first = default(StructType);
        var third = UpperSomeString;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<StructType, RefType?, string?>.From(
                _ => first,
                null!,
                _ => third));

        Assert.Equal("second", ex.ParamName);
    }

    [Fact]
    public void From_Resolver_ThirdIsNull_ExpectArgumentNullException()
    {
        var first = PlusFifteenIdRefType;
        var second = default(RecordType);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<RefType?, RecordType?, StructType?>.From(
                _ => first,
                _ => second,
                null!));

        Assert.Equal("third", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void From_Resolver_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
        RecordType sourceThird)
    {
        var sourceFirst = MinusOne;
        var sourceSecond = LowerSomeTextStructType;

        var actual = Dependency<int?, StructType, RecordType>.From(
            _ => sourceFirst,
            _ => sourceSecond,
            _ => sourceThird);

        var actualValue = actual.Resolve();

        var expectedValue = (sourceFirst, sourceSecond, sourceThird);
        Assert.Equal(expectedValue, actualValue);
    }
}
