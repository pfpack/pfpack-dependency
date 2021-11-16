using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FourDependencyTest
{
    [Fact]
    public void From_Factory_FirstIsNull_ExpectArgumentNullException()
    {
        var second = SomeTextStructType;
        var third = byte.MaxValue;
        var fourth = MinusFifteenIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<RecordType?, StructType?, byte, RefType>.From(
                null!,
                () => second,
                () => third,
                () => fourth));

        Assert.Equal("first", ex.ParamName);
    }

    [Fact]
    public void From_Factory_SecondIsNull_ExpectArgumentNullException()
    {
        var first = LowerSomeTextStructType;
        var third = ZeroIdNullNameRecord;
        var fourth = PlusFifteenIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<StructType, string?, RecordType?, RefType>.From(
                () => first,
                null!,
                () => third,
                () => fourth));

        Assert.Equal("second", ex.ParamName);
    }

    [Fact]
    public void From_Factory_ThirdIsNull_ExpectArgumentNullException()
    {
        var first = MinusFifteenIdSomeStringNameRecord;
        var second = SomeTextStructType;
        var fourth = WhiteSpaceString;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<RecordType, StructType?, RefType, string>.From(
                () => first,
                () => second,
                null!,
                () => fourth));

        Assert.Equal("third", ex.ParamName);
    }

    [Fact]
    public void From_Factory_FourthIsNull_ExpectArgumentNullException()
    {
        var first = SomeString;
        var second = PlusFifteenIdLowerSomeStringNameRecord;
        var third = ZeroIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<string, RecordType?, RefType?, StructType>.From(
                () => first,
                () => second,
                () => third,
                null!));

        Assert.Equal("fourth", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void From_Factory_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
        RefType? sourceFourth)
    {
        var sourceFirst = SomeTextStructType;
        var sourceSecond = MinusFifteenIdNullNameRecord;
        var sourceThird = decimal.MinusOne;

        var actual = Dependency<StructType?, RecordType?, decimal, RefType?>.From(
            () => sourceFirst,
            () => sourceSecond,
            () => sourceThird,
            () => sourceFourth);

        var actualValue = actual.Resolve();

        var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth);
        Assert.Equal(expectedValue, actualValue);
    }
}