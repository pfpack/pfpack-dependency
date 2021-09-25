using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class SevenDependencyTest
{
    [Fact]
    public void From_Factory_FirstIsNull_ExpectArgumentNullException()
    {
        var second = long.MinValue;
        var third = EmptyString;
        var fourth = decimal.MinusOne;
        var fifth = PlusFifteenIdRefType;
        var sixth = true;
        var seventh = SomeTextStructType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<RecordType, long, string?, decimal?, RefType, bool, StructType?>.From(
                null!,
                () => second,
                () => third,
                () => fourth,
                () => fifth,
                () => sixth,
                () => seventh));

        Assert.Equal("first", ex.ParamName);
    }

    [Fact]
    public void From_Factory_SecondIsNull_ExpectArgumentNullException()
    {
        var first = byte.MaxValue;
        var third = LowerSomeTextStructType;
        var fourth = int.MaxValue;
        var fifth = MinusFifteenIdRefType;
        var sixth = ZeroIdNullNameRecord;
        var seventh = UpperSomeString;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<byte, object?, StructType, int, RefType, RecordType, string>.From(
                () => first,
                null!,
                () => third,
                () => fourth,
                () => fifth,
                () => sixth,
                () => seventh));

        Assert.Equal("second", ex.ParamName);
    }

    [Fact]
    public void From_Factory_ThirdIsNull_ExpectArgumentNullException()
    {
        var first = DateTimeKind.Utc;
        var second = PlusFifteenIdRefType;
        var fourth = new { Name = ThreeWhiteSpacesString };
        var fifth = uint.MaxValue;
        var sixth = PlusFifteenIdSomeStringNameRecord;
        var seventh = false;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<DateTimeKind, RefType, StructType?, object, uint, RecordType?, bool>.From(
                () => first,
                () => second,
                null!,
                () => fourth,
                () => fifth,
                () => sixth,
                () => seventh));

        Assert.Equal("third", ex.ParamName);
    }

    [Fact]
    public void From_Factory_FourthIsNull_ExpectArgumentNullException()
    {
        var first = default(RefType);
        var second = MinusOne;
        var third = true;
        var fifth = UpperSomeString;
        var sixth = SomeTextStructType;
        var seventh = DateTimeKind.Unspecified;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<RefType?, int, bool?, RecordType?, string, StructType, DateTimeKind>.From(
                () => first,
                () => second,
                () => third,
                null!,
                () => fifth,
                () => sixth,
                () => seventh));

        Assert.Equal("fourth", ex.ParamName);
    }

    [Fact]
    public void From_Factory_FifthIsNull_ExpectArgumentNullException()
    {
        var first = new object();
        var second = MinusFifteenIdSomeStringNameRecord;
        var third = LowerSomeString;
        var fourth = default(long?);
        var sixth = decimal.One;
        var seventh = PlusFifteenIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<object, RecordType, string, long?, bool, decimal, RefType>.From(
                () => first,
                () => second,
                () => third,
                () => fourth,
                null!,
                () => sixth,
                () => seventh));

        Assert.Equal("fifth", ex.ParamName);
    }

    [Fact]
    public void From_Factory_SixthIsNull_ExpectArgumentNullException()
    {
        var first = long.MinValue;
        var second = LowerSomeTextStructType;
        var third = new { Value = byte.MaxValue };
        var fourth = default(RecordType?);
        var fifth = One;
        var seventh = PlusFifteenIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<long, StructType, object, RecordType?, int, string?, RefType>.From(
                () => first,
                () => second,
                () => third,
                () => fourth,
                () => fifth,
                null!,
                () => seventh));

        Assert.Equal("sixth", ex.ParamName);
    }

    [Fact]
    public void From_Factory_SeventhIsNull_ExpectArgumentNullException()
    {
        var first = ZeroIdRefType;
        var second = MixedWhiteSpacesString;
        var third = PlusFifteenIdSomeStringNameRecord;
        var fourth = DateTimeKind.Local;
        var fifth = byte.MaxValue;
        var sixth = SomeTextStructType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = Dependency<RefType, string?, RecordType, DateTimeKind, byte, StructType?, int>.From(
                () => first,
                () => second,
                () => third,
                () => fourth,
                () => fifth,
                () => sixth,
                null!));

        Assert.Equal("seventh", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void From_Factory_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
        StructType sourceSeventh)
    {
        var sourceFirst = MinusFifteenIdNullNameRecord;
        var sourceSecond = SomeString;
        var sourceThird = byte.MaxValue;
        var sourceFourth = PlusFifteenIdRefType;
        var sourceFifth = new object();
        var sourceSixth = uint.MaxValue;

        var actual = Dependency<RecordType?, string, byte, RefType, object, uint?, StructType>.From(
            () => sourceFirst,
            () => sourceSecond,
            () => sourceThird,
            () => sourceFourth,
            () => sourceFifth,
            () => sourceSixth,
            () => sourceSeventh);

        var actualValue = actual.Resolve();

        var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth, sourceSixth, sourceSeventh);
        Assert.Equal(expectedValue, actualValue);
    }
}
