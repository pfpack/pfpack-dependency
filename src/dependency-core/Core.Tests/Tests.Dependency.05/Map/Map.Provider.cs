using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FiveDependencyTest
{
    [Fact]
    public void MapWithProvider_MapFirstFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => SomeTextStructType,
            _ => MinusFifteenIdRefType,
            _ => SomeString,
            _ => MinusFifteenIdSomeStringNameRecord,
            _ => new object());

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (Func<IServiceProvider, StructType, RefType>)null!,
                (_, _) => MinusFifteen,
                (_, _) => decimal.MaxValue,
                (_, _) => decimal.MinusOne,
                (_, _) => UpperSomeString));

        Assert.Equal("mapFirst", ex.ParamName);
    }

    [Fact]
    public void MapWithProvider_MapSecondFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => LowerSomeTextStructType,
            _ => ZeroIdRefType,
            _ => new { Name = SomeString },
            _ => MinusFifteenIdSomeStringNameRecord,
            _ => PlusFifteenIdRefType);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (_, _) => PlusFifteenIdLowerSomeStringNameRecord,
                (Func<IServiceProvider, RefType?, RecordType>)null!,
                (_, _) => long.MaxValue,
                (_, _) => SomeTextStructType,
                (_, _) => TabString));

        Assert.Equal("mapSecond", ex.ParamName);
    }

    [Fact]
    public void MapWithProvider_MapThirdFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => MinusFifteenIdSomeStringNameRecord,
            _ => ZeroIdRefType,
            _ => LowerSomeTextStructType,
            _ => WhiteSpaceString,
            _ => PlusFifteen);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (_, _) => WhiteSpaceString,
                (_, _) => PlusFifteen,
                (Func<IServiceProvider, StructType, RefType>)null!,
                (_, _) => Zero,
                (_, _) => new object()));

        Assert.Equal("mapThird", ex.ParamName);
    }

    [Fact]
    public void MapWithProvider_MapFourthFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => PlusFifteenIdLowerSomeStringNameRecord,
            _ => LowerSomeString,
            _ => long.MaxValue,
            _ => SomeTextStructType,
            _ => EmptyString);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (_, _) => SomeTextStructType,
                (_, _) => decimal.MaxValue,
                (_, _) => MinusFifteenIdSomeStringNameRecord,
                (Func<IServiceProvider, StructType, RecordType>)null!,
                (_, _) => int.MinValue));

        Assert.Equal("mapFourth", ex.ParamName);
    }

    [Fact]
    public void MapWithProvider_MapFifthFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => PlusFifteen,
            _ => UpperSomeString,
            _ => int.MaxValue,
            _ => MinusFifteenIdSomeStringNameRecord,
            _ => PlusFifteenIdRefType);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (_, _) => LowerSomeString,
                (_, _) => MinusFifteenIdRefType,
                (_, _) => MinusFifteenIdSomeStringNameRecord,
                (_, _) => long.MaxValue,
                (Func<IServiceProvider, RefType, decimal?>)null!));

        Assert.Equal("mapFifth", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void MapWithProvider_MapFuncIsNotNull_ExpectResolvedValuesAreEqualToMapped(
        RecordType mappedLast)
    {
        var source = Dependency.From(
            _ => MinusFifteen,
            _ => EmptyString,
            _ => (RefType?)null,
            _ => SomeTextStructType,
            _ => PlusFifteenIdRefType);

        var mappedFirst = UpperSomeString;
        var mappedSecond = decimal.One;
        var mappedThird = ZeroIdNullNameRecord;
        var mappedFourth = default(int?);

        var actual = source.Map(
            (_, _) => mappedFirst,
            (_, _) => mappedSecond,
            (_, _) => mappedThird,
            (_, _) => mappedFourth,
            (_, _) => mappedLast);

        var actualValue = actual.Resolve();
        var expectedValue = (mappedFirst, mappedSecond, mappedThird, mappedFourth, mappedLast);

        Assert.Equal(expectedValue, actualValue);
    }
}