using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class EightDependencyTest
{
    [Fact]
    public void MapWithProvider_MapFirstFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => SomeTextStructType,
            _ => (true, false),
            _ => DateTimeOffset.MaxValue,
            _ => MinusOne,
            _ => PlusFifteenIdLowerSomeStringNameRecord,
            _ => WhiteSpaceString,
            _ => decimal.One,
            _ => ZeroIdRefType);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (Func<IServiceProvider, StructType, Tuple<string?, RecordType>?>)null!,
                (_, _) => MinusFifteenIdNullNameRecord,
                (_, _) => LowerSomeTextStructType,
                (_, _) => EmptyString,
                (_, _) => DateTimeKind.Unspecified,
                (_, _) => PlusFifteenIdRefType,
                (_, _) => byte.MaxValue,
                (_, _) => new { Text = SomeString }));

        Assert.Equal("mapFirst", ex.ParamName);
    }

    [Fact]
    public void MapWithProvider_MapSecondFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => MinusFifteen,
            _ => PlusFifteenIdRefType,
            _ => UpperSomeString,
            _ => ZeroIdNullNameRecord,
            _ => new object(),
            _ => new Tuple<int, string>(PlusFifteen, EmptyString),
            _ => true,
            _ => LowerSomeTextStructType);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (_, _) => TwoTabsString,
                (Func<IServiceProvider, RefType, int>)null!,
                (_, _) => MinusFifteenIdSomeStringNameRecord,
                (_, _) => One,
                (_, _) => decimal.MinValue,
                (_, _) => LowerSomeTextStructType,
                (_, _) => new { Value = ThreeWhiteSpacesString },
                (_, _) => MinusFifteenIdRefType));

        Assert.Equal("mapSecond", ex.ParamName);
    }

    [Fact]
    public void MapWithProvider_MapThirdFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => decimal.MinValue,
            _ => UpperSomeString,
            _ => PlusFifteenIdLowerSomeStringNameRecord,
            _ => SomeTextStructType,
            _ => MinusFifteenIdRefType,
            _ => false,
            _ => new Tuple<string, long>(EmptyString, long.MinValue),
            _ => DateTimeKind.Local);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (_, _) => new object(),
                (_, _) => ZeroIdRefType,
                (Func<IServiceProvider, RecordType?, int>)null!,
                (_, _) => decimal.One,
                (_, _) => PlusFifteenIdSomeStringNameRecord,
                (_, _) => byte.MaxValue,
                (_, _) => LowerSomeTextStructType,
                (_, _) => new Tuple<RefType?, bool?>(PlusFifteenIdRefType, true)));

        Assert.Equal("mapThird", ex.ParamName);
    }

    [Fact]
    public void MapWithProvider_MapFourthFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => new { Text = SomeString },
            _ => LowerSomeTextStructType,
            _ => ThreeWhiteSpacesString,
            _ => Zero,
            _ => PlusFifteenIdLowerSomeStringNameRecord,
            _ => false,
            _ => ZeroIdRefType,
            _ => DateTimeKind.Local);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (_, _) => MinusFifteenIdRefType,
                (_, _) => int.MaxValue,
                (_, _) => (true, EmptyString),
                (Func<IServiceProvider, int, RecordType?>)null!,
                (_, _) => byte.MaxValue,
                (_, _) => SomeTextStructType,
                (_, _) => int.MinValue,
                (_, _) => new object()));

        Assert.Equal("mapFourth", ex.ParamName);
    }

    [Fact]
    public void MapWithProvider_MapFifthFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => PlusFifteenIdLowerSomeStringNameRecord,
            _ => NullTextStructType,
            _ => new object(),
            _ => decimal.One,
            _ => MinusFifteenIdRefType,
            _ => (PlusFifteen, DateTime.MaxValue),
            _ => LowerSomeString,
            _ => new[] { MinusOne, PlusFifteen, int.MinValue });

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (_, _) => false,
                (_, _) => MinusFifteen,
                (_, _) => EmptyString,
                (_, _) => MinusFifteenIdNullNameRecord,
                (Func<IServiceProvider, RefType?, decimal>)null!,
                (_, _) => SomeTextStructType,
                (_, _) => ZeroIdRefType,
                (_, _) => DateTimeKind.Unspecified));

        Assert.Equal("mapFifth", ex.ParamName);
    }

    [Fact]
    public void MapWithProvider_MapSixthFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => (long.MinValue, EmptyString),
            _ => new[] { true, false, true },
            _ => DateTimeKind.Utc,
            _ => SomeTextStructType,
            _ => PlusFifteenIdRefType,
            _ => new { Name = SomeString, Value = decimal.One },
            _ => LowerSomeString,
            _ => MinusFifteenIdSomeStringNameRecord);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (_, _) => UpperSomeString,
                (_, _) => ZeroIdNullNameRecord,
                (_, _) => MinusFifteenIdRefType,
                (_, _) => decimal.MaxValue,
                (_, _) => new Tuple<string, DateTime>(ThreeWhiteSpacesString, DateTime.MinValue),
                (Func<IServiceProvider, object?, DateTime>)null!,
                (_, _) => (PlusFifteen, TabString),
                (_, _) => LowerSomeTextStructType));

        Assert.Equal("mapSixth", ex.ParamName);
    }

    [Fact]
    public void MapWithProvider_MapSeventhFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => MinusFifteenIdSomeStringNameRecord,
            _ => new object(),
            _ => new[] { EmptyString, SomeString, WhiteSpaceString },
            _ => DateTimeKind.Local,
            _ => TwoTabsString,
            _ => new Tuple<byte, RefType?>(Zero, MinusFifteenIdRefType),
            _ => (StructType?)LowerSomeTextStructType,
            _ => ZeroIdRefType);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (_, _) => SomeTextStructType,
                (_, _) => long.MinValue,
                (_, _) => false,
                (_, _) => PlusFifteenIdSomeStringNameRecord,
                (_, _) => decimal.MinusOne,
                (_, _) => PlusFifteenIdRefType,
                (Func<IServiceProvider, StructType?, string>)null!,
                (_, _) => new { Name = SomeString }));

        Assert.Equal("mapSeventh", ex.ParamName);
    }

    [Fact]
    public void MapWithProvider_MapRestFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => false,
            _ => SomeTextStructType,
            _ => MinusFifteenIdNullNameRecord,
            _ => new { Id = PlusFifteen },
            _ => int.MaxValue,
            _ => ZeroIdRefType,
            _ => byte.MaxValue,
            _ => UpperSomeString);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (_, _) => EmptyString,
                (_, _) => Array.Empty<DateTime>(),
                (_, _) => (long.MaxValue, MinusFifteenIdRefType),
                (_, _) => decimal.MinValue,
                (_, _) => new object(),
                (_, _) => LowerSomeTextStructType,
                (_, _) => PlusFifteenIdSomeStringNameRecord,
                (Func<IServiceProvider, string, RecordType>)null!));

        Assert.Equal("mapRest", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void MapWithProvider_MapFuncIsNotNull_ExpectResolvedValuesAreEqualToMapped(
        RefType? mappedLast)
    {
        var source = Dependency.From(
            _ => MinusFifteenIdSomeStringNameRecord,
            _ => MinusFifteen,
            _ => new Tuple<bool?, string, int>(null, WhiteSpaceString, int.MaxValue),
            _ => LowerSomeTextStructType,
            _ => MinusFifteenIdRefType,
            _ => new { Value = byte.MaxValue },
            _ => DateTimeKind.Utc,
            _ => new[] { long.MaxValue });

        var mappedFirst = DateTimeKind.Local;
        var mappedSecond = PlusFifteenIdLowerSomeStringNameRecord;
        var mappedThird = decimal.One;
        var mappedFourth = Array.Empty<DateTimeOffset>();
        var mappedFifth = (true, UpperSomeString);
        var mappedSixth = SomeTextStructType;
        var mappedSeventh = new object();

        var actual = source.Map(
            (_, _) => mappedFirst,
            (_, _) => mappedSecond,
            (_, _) => mappedThird,
            (_, _) => mappedFourth,
            (_, _) => mappedFifth,
            (_, _) => mappedSixth,
            (_, _) => mappedSeventh,
            (_, _) => mappedLast);

        var actualValue = actual.Resolve();
        var expectedValue = ((mappedFirst, mappedSecond, mappedThird, mappedFourth), (mappedFifth, mappedSixth, mappedSeventh, mappedLast));

        Assert.Equal(expectedValue, actualValue);
    }
}
