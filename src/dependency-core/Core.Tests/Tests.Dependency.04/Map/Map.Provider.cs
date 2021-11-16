using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FourDependencyTest
{
    [Fact]
    public void MapWithProvider_MapFirstFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => SomeTextStructType, _ => int.MaxValue, _ => decimal.MinusOne, _ => PlusFifteenIdRefType);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (Func<IServiceProvider, StructType, DateTimeOffset?>)null!,
                (_, _) => LowerSomeString,
                (_, _) => new object(),
                (_, _) => Zero));

        Assert.Equal("mapFirst", ex.ParamName);
    }

    [Fact]
    public void MapWithProvider_MapSecondFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => int.MinValue, _ => MinusFifteen, _ => PlusFifteenIdRefType, _ => SomeString);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (_, _) => PlusFifteenIdLowerSomeStringNameRecord,
                (Func<IServiceProvider, int, long>)null!,
                (_, _) => SomeString,
                (_, _) => MinusFifteenIdRefType));

        Assert.Equal("mapSecond", ex.ParamName);
    }

    [Fact]
    public void MapWithProvider_MapThirdFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => SomeTextStructType, _ => MinusFifteenIdRefType, _ => new object(), _ => int.MaxValue);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (_, _) => int.MinValue,
                (_, _) => decimal.Zero,
                (Func<IServiceProvider, object?, RefType?>)null!,
                (_, _) => UpperSomeString));

        Assert.Equal("mapThird", ex.ParamName);
    }

    [Fact]
    public void MapWithProvider_MapFourthFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => LowerSomeString, _ => PlusFifteenIdRefType, _ => int.MinValue, _ => MinusFifteenIdSomeStringNameRecord);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Map(
                (_, _) => MinusFifteenIdRefType,
                (_, _) => LowerSomeString,
                (_, _) => UpperSomeString,
                (Func<IServiceProvider, RecordType, RefType>)null!));

        Assert.Equal("mapFourth", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void MapWithProvider_MapFuncIsNotNull_ExpectResolvedValuesAreEqualToMapped(
        StructType mappedLast)
    {
        var source = Dependency.From(
            _ => MinusFifteen,
            _ => UpperSomeString,
            _ => LowerSomeTextStructType,
            _ => MinusFifteenIdRefType);

        var mappedFirst = MinusFifteenIdNullNameRecord;
        var mappedSecond = ZeroIdRefType;
        var mappedThird = LowerSomeString;

        var actual = source.Map(
            (_, _) => mappedFirst,
            (_, _) => mappedSecond,
            (_, _) => mappedThird,
            (_, _) => mappedLast);

        var actualValue = actual.Resolve();
        var expectedValue = (mappedFirst, mappedSecond, mappedThird, mappedLast);

        Assert.Equal(expectedValue, actualValue);
    }
}