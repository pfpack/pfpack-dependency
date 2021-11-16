using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class TwoDependencyTest
{
    [Fact]
    public void WithSixResolvers_ThirdIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => MinusFifteenIdRefType, _ => PlusFifteen);

        var fourthValue = DateTimeKind.Unspecified;
        var fifthValue = SomeTextStructType;

        var sixthValue = long.MinValue;
        var seventhValue = PlusFifteenIdLowerSomeStringNameRecord;

        var restValue = new object();

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                (Func<IServiceProvider, DateTimeOffset>)null!,
                _ => fourthValue,
                _ => fifthValue,
                _ => sixthValue,
                _ => seventhValue,
                _ => restValue));

        Assert.Equal("third", ex.ParamName);
    }

    [Fact]
    public void WithSixResolvers_FourthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => decimal.One, _ => MinusFifteenIdRefType);

        var thirdValue = byte.MaxValue;
        var fifthValue = PlusFifteenIdSomeStringNameRecord;

        var sixthValue = long.MaxValue;
        var seventhValue = new object();

        var restValue = LowerSomeTextStructType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => thirdValue,
                (Func<IServiceProvider, string?>)null!,
                _ => fifthValue,
                _ => sixthValue,
                _ => seventhValue,
                _ => restValue));

        Assert.Equal("fourth", ex.ParamName);
    }

    [Fact]
    public void WithSixResolvers_FifthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => SomeTextStructType, _ => PlusFifteenIdRefType);

        var thirdValue = int.MinValue;
        var fourthValue = false;

        var sixthValue = ZeroIdNullNameRecord;
        var seventhValue = DateTimeKind.Local;

        var restValue = SomeString;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => thirdValue,
                _ => fourthValue,
                (Func<IServiceProvider, object?>)null!,
                _ => sixthValue,
                _ => seventhValue,
                _ => restValue));

        Assert.Equal("fifth", ex.ParamName);
    }

    [Fact]
    public void WithSixResolvers_SixthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => decimal.MinusOne, _ => PlusFifteenIdRefType);

        var thirdValue = true;
        var fourthValue = LowerSomeString;

        var fifthValue = new { Id = PlusFifteen };
        var seventhValue = MinusFifteenIdSomeStringNameRecord;

        var restValue = SomeTextStructType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => thirdValue,
                _ => fourthValue,
                _ => fifthValue,
                (Func<IServiceProvider, bool>)null!,
                _ => seventhValue,
                _ => restValue));

        Assert.Equal("sixth", ex.ParamName);
    }

    [Fact]
    public void WithSixResolvers_SeventhIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => MinusOne, _ => MinusFifteenIdSomeStringNameRecord);

        var thirdValue = decimal.One;
        var fourthValue = Array.Empty<string?>();

        var fifthValue = PlusFifteenIdRefType;
        var sixthValue = LowerSomeTextStructType;

        var restValue = DateTimeKind.Utc;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => thirdValue,
                _ => fourthValue,
                _ => fifthValue,
                _ => sixthValue,
                (Func<IServiceProvider, object?>)null!,
                _ => restValue));

        Assert.Equal("seventh", ex.ParamName);
    }

    [Fact]
    public void WithSixResolvers_RestIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => SomeString, _ => true);

        var thirdValue = DateTimeKind.Local;
        var fourthValue = PlusFifteenIdRefType;

        var fifthValue = LowerSomeTextStructType;
        var sixthValue = ZeroIdNullNameRecord;

        var seventhValue = new object();

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => thirdValue,
                _ => fourthValue,
                _ => fifthValue,
                _ => sixthValue,
                _ => seventhValue,
                (Func<IServiceProvider, RecordType>)null!));

        Assert.Equal("rest", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void WithSixResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        StructType lastValue)
    {
        var firstSource = PlusFifteenIdLowerSomeStringNameRecord;
        var secondSource = MinusOne;

        var source = Dependency.From(_ => firstSource, _ => secondSource);

        var thirdValue = false;
        var fourthValue = Array.Empty<DateTime?>();

        var fifthValue = PlusFifteenIdRefType;
        var sixthValue = UpperSomeString;

        var seventhValue = DateTimeKind.Utc;

        var actual = source.With(_ => thirdValue, _ => fourthValue, _ => fifthValue, _ => sixthValue, _ => seventhValue, _ => lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = ((firstSource, secondSource, thirdValue, fourthValue), (fifthValue, sixthValue, seventhValue, lastValue));
        Assert.Equal(expectedValue, actualValue);
    }
}