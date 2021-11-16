using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class ThreeDependencyTest
{
    [Fact]
    public void WithFiveFactories_FourthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => MinusFifteenIdRefType, _ => new object(), _ => decimal.MaxValue);

        var fifthValue = false;
        var sixthValue = UpperSomeString;

        var seventhValue = MinusOne;
        var restValue = PlusFifteenIdSomeStringNameRecord;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                (Func<StructType?>)null!,
                () => fifthValue,
                () => sixthValue,
                () => seventhValue,
                () => restValue));

        Assert.Equal("fourth", ex.ParamName);
    }

    [Fact]
    public void WithFiveFactories_FifthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => long.MinValue, _ => true, _ => SomeTextStructType);

        var fourthValue = ThreeWhiteSpacesString;
        var sixthValue = DateTimeKind.Utc;

        var seventhValue = ZeroIdNullNameRecord;
        var restValue = default(DateTimeKind?);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => fourthValue,
                (Func<RefType>)null!,
                () => sixthValue,
                () => seventhValue,
                () => restValue));

        Assert.Equal("fifth", ex.ParamName);
    }

    [Fact]
    public void WithFiveFactories_SixthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => LowerSomeTextStructType, _ => long.MinValue, _ => new object());

        var fourthValue = PlusFifteenIdSomeStringNameRecord;
        var fifthValue = One;

        var seventhValue = DateTimeKind.Unspecified;
        var restValue = MinusFifteenIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => fourthValue,
                () => fifthValue,
                (Func<string?>)null!,
                () => seventhValue,
                () => restValue));

        Assert.Equal("sixth", ex.ParamName);
    }

    [Fact]
    public void WithFiveFactories_SeventhIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => default(string), _ => SomeTextStructType, _ => decimal.MinusOne);

        var fourthValue = new object();
        var fifthValue = new[] { long.MaxValue, long.MinValue };

        var sixthValue = true;
        var restValue = MinusFifteenIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => fourthValue,
                () => fifthValue,
                () => sixthValue,
                (Func<RecordType?>)null!,
                () => restValue));

        Assert.Equal("seventh", ex.ParamName);
    }

    [Fact]
    public void WithFiveFactories_RestIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => false, _ => PlusFifteenIdLowerSomeStringNameRecord, _ => SomeTextStructType);

        var fourthValue = new object();
        var fifthValue = DateTimeKind.Utc;

        var sixthValue = long.MaxValue;
        var seventhValue = ZeroIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => fourthValue,
                () => fifthValue,
                () => sixthValue,
                () => seventhValue,
                (Func<decimal>)null!));

        Assert.Equal("rest", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void WithFiveFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        StructType lastValue)
    {
        var firstSource = PlusFifteenIdRefType;
        var secondSource = decimal.MaxValue;

        var thirdSource = EmptyString;
        var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource);

        var fourthValue = ZeroIdNullNameRecord;
        var fifthValue = new { Id = One };

        var sixthValue = true;
        var seventhValue = new[] { byte.MaxValue };

        var actual = source.With(() => fourthValue, () => fifthValue, () => sixthValue, () => seventhValue, () => lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = ((firstSource, secondSource, thirdSource, fourthValue), (fifthValue, sixthValue, seventhValue, lastValue));
        Assert.Equal(expectedValue, actualValue);
    }
}