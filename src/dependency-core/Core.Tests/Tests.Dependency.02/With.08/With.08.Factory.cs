using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class TwoDependencyTest
{
    [Fact]
    public void WithSixFactories_ThirdIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => PlusFifteenIdSomeStringNameRecord, _ => decimal.One);

        var fourthValue = Array.Empty<long?>();
        var fifthValue = MinusFifteenIdRefType;

        var sixthValue = true;
        var seventhValue = LowerSomeTextStructType;

        var restValue = byte.MaxValue;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                (Func<string>)null!,
                () => fourthValue,
                () => fifthValue,
                () => sixthValue,
                () => seventhValue,
                () => restValue));

        Assert.Equal("third", ex.ParamName);
    }

    [Fact]
    public void WithSixFactories_FourthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => new { Id = One }, _ => ZeroIdRefType);

        var thirdValue = MinusFifteenIdSomeStringNameRecord;
        var fifthValue = false;

        var sixthValue = ThreeWhiteSpacesString;
        var seventhValue = DateTimeKind.Unspecified;

        var restValue = new[] { byte.MaxValue };

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => thirdValue,
                (Func<StructType?>)null!,
                () => fifthValue,
                () => sixthValue,
                () => seventhValue,
                () => restValue));

        Assert.Equal("fourth", ex.ParamName);
    }

    [Fact]
    public void WithSixFactories_FifthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => true, _ => MinusOne);

        var thirdValue = new object();
        var fourthValue = SomeTextStructType;

        var sixthValue = DateTimeKind.Utc;
        var seventhValue = byte.MaxValue;

        var restValue = PlusFifteenIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => thirdValue,
                () => fourthValue,
                (Func<RecordType?>)null!,
                () => sixthValue,
                () => seventhValue,
                () => restValue));

        Assert.Equal("fifth", ex.ParamName);
    }

    [Fact]
    public void WithSixFactories_SixthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => Array.Empty<DateTimeOffset>(), _ => LowerSomeTextStructType);

        var thirdValue = new object();
        var fourthValue = ZeroIdNullNameRecord;

        var fifthValue = long.MinValue;
        var seventhValue = EmptyString;

        var restValue = true;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => thirdValue,
                () => fourthValue,
                () => fifthValue,
                (Func<RefType>)null!,
                () => seventhValue,
                () => restValue));

        Assert.Equal("sixth", ex.ParamName);
    }

    [Fact]
    public void WithSixFactories_SeventhIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => PlusFifteenIdSomeStringNameRecord, _ => int.MaxValue);

        var thirdValue = DateTimeKind.Local;
        var fourthValue = SomeTextStructType;

        var fifthValue = new object();
        var sixthValue = MinusFifteenIdRefType;

        var restValue = UpperSomeString;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => thirdValue,
                () => fourthValue,
                () => fifthValue,
                () => sixthValue,
                (Func<bool[]>)null!,
                () => restValue));

        Assert.Equal("seventh", ex.ParamName);
    }

    [Fact]
    public void WithSixFactories_RestIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => DateTimeKind.Unspecified, _ => MinusFifteenIdRefType);

        var thirdValue = SomeTextStructType;
        var fourthValue = MinusOne;

        var fifthValue = true;
        var sixthValue = byte.MaxValue;

        var seventhValue = PlusFifteenIdLowerSomeStringNameRecord;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => thirdValue,
                () => fourthValue,
                () => fifthValue,
                () => sixthValue,
                () => seventhValue,
                (Func<object?>)null!));

        Assert.Equal("rest", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void WithSixFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        RefType lastValue)
    {
        var firstSource = ThreeWhiteSpacesString;
        var secondSource = new object();

        var source = Dependency.From(_ => firstSource, _ => secondSource);

        var thirdValue = SomeTextStructType;
        var fourthValue = byte.MaxValue;

        var fifthValue = DateTimeKind.Local;
        var sixthValue = MinusFifteenIdSomeStringNameRecord;

        var seventhValue = One;

        var actual = source.With(
            () => thirdValue, () => fourthValue, () => fifthValue, () => sixthValue, () => seventhValue, () => lastValue);

        var actualValue = actual.Resolve();

        var expectedValue = ((firstSource, secondSource, thirdValue, fourthValue), (fifthValue, sixthValue, seventhValue, lastValue));
        Assert.Equal(expectedValue, actualValue);
    }
}