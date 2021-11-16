using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class TwoDependencyTest
{
    [Fact]
    public void WithFiveFactories_ThirdIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => new object(), _ => byte.MaxValue);

        var fourthValue = MinusFifteenIdSomeStringNameRecord;
        var fifthValue = SomeTextStructType;

        var sixthValue = false;
        var lastValue = PlusFifteenIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                (Func<long>)null!,
                () => fourthValue,
                () => fifthValue,
                () => sixthValue,
                () => lastValue));

        Assert.Equal("third", ex.ParamName);
    }

    [Fact]
    public void WithFiveFactories_FourthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => SomeTextStructType, _ => DateTimeKind.Unspecified);

        var thirdValue = new object();
        var fifthValue = PlusFifteenIdRefType;

        var sixthValue = decimal.MinusOne;
        var lastValue = ThreeWhiteSpacesString;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => thirdValue,
                (Func<RecordType?>)null!,
                () => fifthValue,
                () => sixthValue,
                () => lastValue));

        Assert.Equal("fourth", ex.ParamName);
    }

    [Fact]
    public void WithFiveFactories_FifthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => long.MinValue, _ => UpperSomeString);

        var thirdValue = new { Id = MinusOne };
        var fourthValue = SomeTextStructType;

        var sixthValue = MinusFifteenIdNullNameRecord;
        var lastValue = byte.MaxValue;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => thirdValue,
                () => fourthValue,
                (Func<RefType>)null!,
                () => sixthValue,
                () => lastValue));

        Assert.Equal("fifth", ex.ParamName);
    }

    [Fact]
    public void WithFiveFactories_SixthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => MinusOne, _ => PlusFifteenIdSomeStringNameRecord);

        var thirdValue = long.MinValue;
        var fourthValue = new object();

        var fifthValue = LowerSomeTextStructType;
        var lastValue = MinusFifteenIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => thirdValue,
                () => fourthValue,
                () => fifthValue,
                (Func<RefType>)null!,
                () => lastValue));

        Assert.Equal("sixth", ex.ParamName);
    }

    [Fact]
    public void WithFiveFactories_SeventhIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => new object(), _ => false);

        var thirdValue = MinusFifteenIdRefType;
        var fourthValue = long.MaxValue;

        var fifthValue = DateTimeKind.Local;
        var sixthValue = ZeroIdNullNameRecord;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => thirdValue,
                () => fourthValue,
                () => fifthValue,
                () => sixthValue,
                (Func<StructType?>)null!));

        Assert.Equal("seventh", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void WithFiveFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        RecordType lastValue)
    {
        var firstSource = LowerSomeTextStructType;
        var secondSource = decimal.MinValue;

        var source = Dependency.From(_ => firstSource, _ => secondSource);

        var thirdValue = ThreeWhiteSpacesString;
        var fourthValue = PlusFifteenIdRefType;

        var fifthValue = long.MinValue;
        var sixthValue = new object();

        var actual = source.With(() => thirdValue, () => fourthValue, () => fifthValue, () => sixthValue, () => lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdValue, fourthValue, fifthValue, sixthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}