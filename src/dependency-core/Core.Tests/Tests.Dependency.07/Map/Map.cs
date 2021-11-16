using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class SevenDependencyTest
{
    [Fact]
    public void Map_MapFirstFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => SomeString,
            _ => new object(),
            _ => PlusFifteenIdLowerSomeStringNameRecord,
            _ => decimal.One,
            _ => long.MaxValue,
            _ => MinusFifteenIdRefType,
            _ => LowerSomeTextStructType);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (Func<string, RefType?>)null!,
                _ => SomeTextStructType,
                _ => MinusFifteen,
                _ => new { Value = decimal.One },
                _ => DateTimeKind.Utc,
                _ => false,
                _ => MinusFifteenIdNullNameRecord));

        Assert.Equal("mapFirst", ex.ParamName);
    }

    [Fact]
    public void Map_MapSecondFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => byte.MaxValue,
            _ => SomeTextStructType,
            _ => MinusFifteen,
            _ => true,
            _ => new { nameof = WhiteSpaceString },
            _ => PlusFifteenIdRefType,
            _ => MinusFifteenIdSomeStringNameRecord);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                _ => ZeroIdRefType,
                (Func<StructType, DateTime>)null!,
                _ => DateTimeKind.Unspecified,
                _ => new object(),
                _ => WhiteSpaceString,
                _ => LowerSomeTextStructType,
                _ => ZeroIdRefType));

        Assert.Equal("mapSecond", ex.ParamName);
    }

    [Fact]
    public void Map_MapThirdFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => PlusFifteenIdLowerSomeStringNameRecord,
            _ => DateTimeKind.Local,
            _ => MinusFifteenIdRefType,
            _ => Zero,
            _ => UpperSomeString,
            _ => SomeTextStructType,
            _ => new object());

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                _ => new { Name = SomeString },
                _ => ZeroIdRefType,
                (Func<RefType?, (string? Name, decimal Value)>)null!,
                _ => true,
                _ => decimal.MaxValue,
                _ => MinusFifteen,
                _ => DateTimeKind.Utc));

        Assert.Equal("mapThird", ex.ParamName);
    }

    [Fact]
    public void Map_MapFourthFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => PlusFifteenIdRefType,
            _ => SomeString,
            _ => new object(),
            _ => MinusFifteenIdSomeStringNameRecord,
            _ => DateTimeKind.Local,
            _ => decimal.One,
            _ => MinusFifteen);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                _ => ZeroIdNullNameRecord,
                _ => int.MaxValue,
                _ => UpperSomeString,
                (Func<RecordType, DateTime>)null!,
                _ => false,
                _ => ZeroIdRefType,
                _ => new { Name = ThreeWhiteSpacesString }));

        Assert.Equal("mapFourth", ex.ParamName);
    }

    [Fact]
    public void Map_MapFifthFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => new { Name = SomeString },
            _ => LowerSomeTextStructType,
            _ => UpperSomeString,
            _ => ZeroIdRefType,
            _ => PlusFifteenIdLowerSomeStringNameRecord,
            _ => DateTimeKind.Unspecified,
            _ => true);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                _ => MinusFifteen,
                _ => MinusFifteenIdRefType,
                _ => decimal.MinusOne,
                _ => SomeTextStructType,
                (Func<RecordType, object?>)null!,
                _ => MinusFifteenIdNullNameRecord,
                _ => byte.MaxValue));

        Assert.Equal("mapFifth", ex.ParamName);
    }

    [Fact]
    public void Map_MapSixthFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => PlusFifteen,
            _ => SomeTextStructType,
            _ => new object(),
            _ => WhiteSpaceString,
            _ => DateTimeKind.Utc,
            _ => MinusFifteenIdRefType,
            _ => ZeroIdNullNameRecord);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                _ => TabString,
                _ => decimal.MaxValue,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => PlusFifteenIdRefType,
                _ => true,
                (Func<RefType?, DateTimeOffset>)null!,
                _ => new { Text = SomeString }));

        Assert.Equal("mapSixth", ex.ParamName);
    }

    [Fact]
    public void Map_MapSeventhFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => MinusFifteenIdRefType,
            _ => ZeroIdNullNameRecord,
            _ => false,
            _ => SomeTextStructType,
            _ => (PlusFifteen, SomeString),
            _ => decimal.MinusOne,
            _ => new { Id = MinusFifteen });

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                _ => LowerSomeTextStructType,
                _ => long.MinValue,
                _ => PlusFifteen,
                _ => WhiteSpaceString,
                _ => new object(),
                _ => DateTimeKind.Local,
                (Func<object, RefType>)null!));

        Assert.Equal("mapSeventh", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void Map_MapFuncIsNotNull_ExpectResolvedValuesAreEqualToMapped(
        RefType mappedLast)
    {
        var source = Dependency.From(
            _ => MinusFifteenIdSomeStringNameRecord,
            _ => LowerSomeString,
            _ => PlusFifteenIdRefType,
            _ => new object(),
            _ => MinusFifteen,
            _ => SomeTextStructType,
            _ => DateTimeKind.Local);

        var mappedFirst = LowerSomeTextStructType;
        var mappedSecond = byte.MaxValue;
        var mappedThird = true;
        var mappedFourth = decimal.MaxValue;
        var mappedFifth = PlusFifteenIdSomeStringNameRecord;
        var mappedSixth = WhiteSpaceString;

        var actual = source.Map(
            _ => mappedFirst,
            _ => mappedSecond,
            _ => mappedThird,
            _ => mappedFourth,
            _ => mappedFifth,
            _ => mappedSixth,
            _ => mappedLast);

        var actualValue = actual.Resolve();
        var expectedValue = (mappedFirst, mappedSecond, mappedThird, mappedFourth, mappedFifth, mappedSixth, mappedLast);

        Assert.Equal(expectedValue, actualValue);
    }
}