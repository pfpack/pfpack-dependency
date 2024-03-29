using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FiveDependencyTest
{
    [Fact]
    public void From_Resolver_FirstIsNull_ExpectArgumentNullException()
    {
        var second = LowerSomeTextStructType;
        var third = new object();
        var fourth = MinusOne;
        var fifth = ZeroIdNullNameRecord;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<RefType?, StructType, object, int, RecordType?>.From(
                null!,
                _ => second,
                _ => third,
                _ => fourth,
                _ => fifth));

        Assert.Equal("first", ex.ParamName);
    }

    [Fact]
    public void From_Resolver_SecondIsNull_ExpectArgumentNullException()
    {
        var first = PlusFifteenIdLowerSomeStringNameRecord;
        var third = ZeroIdRefType;
        var fourth = LowerSomeTextStructType;
        var fifth = UpperSomeString;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<RecordType, int?, RefType?, StructType, string>.From(
                _ => first,
                null!,
                _ => third,
                _ => fourth,
                _ => fifth));

        Assert.Equal("second", ex.ParamName);
    }

    [Fact]
    public void From_Resolver_ThirdIsNull_ExpectArgumentNullException()
    {
        var first = default(StructType);
        var second = MinusFifteenIdNullNameRecord;
        var fourth = PlusFifteenIdRefType;
        var fifth = new { Name = SomeString };

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<StructType, RecordType?, long?, RefType, object>.From(
                _ => first,
                _ => second,
                null!,
                _ => fourth,
                _ => fifth));

        Assert.Equal("third", ex.ParamName);
    }

    [Fact]
    public void From_Resolver_FourthIsNull_ExpectArgumentNullException()
    {
        var first = SomeTextStructType;
        var second = EmptyString;
        var third = false;
        var fifth = MinusFifteenIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<StructType?, string, bool, RecordType, RefType?>.From(
                _ => first,
                _ => second,
                _ => third,
                null!,
                _ => fifth));

        Assert.Equal("fourth", ex.ParamName);
    }

    [Fact]
    public void From_Resolver_FifthIsNull_ExpectArgumentNullException()
    {
        var first = One;
        var second = LowerSomeTextStructType;
        var third = MinusFifteenIdRefType;
        var fourth = ZeroIdNullNameRecord;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<int, StructType?, RefType, RecordType?, string[]>.From(
                _ => first,
                _ => second,
                _ => third,
                _ => fourth,
                null!));

        Assert.Equal("fifth", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void From_Resolver_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
        RefType sourceFifth)
    {
        var sourceFirst = SomeTextStructType;
        var sourceSecond = long.MaxValue;
        var sourceThird = MinusFifteenIdNullNameRecord;
        var sourceFourth = false;

        var actual = Dependency<StructType, long, RecordType?, bool?, RefType>.From(
            _ => sourceFirst,
            _ => sourceSecond,
            _ => sourceThird,
            _ => sourceFourth,
            _ => sourceFifth);

        var actualValue = actual.Resolve();

        var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth);
        Assert.Equal(expectedValue, actualValue);
    }
}