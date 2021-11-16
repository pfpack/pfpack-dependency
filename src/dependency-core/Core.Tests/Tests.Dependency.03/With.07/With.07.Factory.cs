using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class ThreeDependencyTest
{
    [Fact]
    public void WithFourFactories_FourthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => WhiteSpaceString, _ => long.MaxValue, _ => DateTimeKind.Utc);

        var fifthValue = PlusFifteenIdRefType;
        var sixthValue = SomeTextStructType;

        var seventhValue = true;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                (Func<RecordType?>)null!,
                () => fifthValue,
                () => sixthValue,
                () => seventhValue));

        Assert.Equal("fourth", ex.ParamName);
    }

    [Fact]
    public void WithFourFactories_FifthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => new object(), _ => true, _ => PlusFifteenIdSomeStringNameRecord);

        var fourthValue = DateTimeKind.Local;
        var sixthValue = decimal.MaxValue;

        var seventhValue = MinusFifteenIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => fourthValue,
                (Func<StructType>)null!,
                () => sixthValue,
                () => seventhValue));

        Assert.Equal("fifth", ex.ParamName);
    }

    [Fact]
    public void WithFourFactories_SixthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => PlusFifteenIdRefType, _ => DateTimeKind.Unspecified, _ => LowerSomeTextStructType);

        var fourthValue = TabString;
        var fifthValue = Array.Empty<DateTime>();

        var seventhValue = ZeroIdNullNameRecord;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => fourthValue,
                () => fifthValue,
                (Func<long?>)null!,
                () => seventhValue));

        Assert.Equal("sixth", ex.ParamName);
    }

    [Fact]
    public void WithFourFactories_SeventhIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => EmptyString, _ => SomeTextStructType, _ => true);

        var fourthValue = PlusFifteenIdLowerSomeStringNameRecord;
        var fifthValue = new object();

        var sixthValue = decimal.MaxValue;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => fourthValue,
                () => fifthValue,
                () => sixthValue,
                (Func<RefType>)null!));

        Assert.Equal("seventh", ex.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    [InlineData(SomeString)]
    public void WithFourFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        string? lastValue)
    {
        var firstSource = new object();
        var secondSource = PlusFifteenIdRefType;

        var thirdSource = decimal.MaxValue;
        var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource);

        var fourthValue = LowerSomeTextStructType;
        var fifthValue = long.MinValue;

        var sixthValue = MinusFifteenIdSomeStringNameRecord;

        var actual = source.With(() => fourthValue, () => fifthValue, () => sixthValue, () => lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdSource, fourthValue, fifthValue, sixthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}