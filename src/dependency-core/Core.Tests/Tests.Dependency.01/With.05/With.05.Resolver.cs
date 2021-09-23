using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class OneDependencyTest
{
    [Fact]
    public void WithFourResolvers_SecondIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => PlusFifteenIdRefType);

        var thirdValue = LowerSomeTextStructType;
        var fourthValue = MixedWhiteSpacesString;

        var lastValue = ZeroIdNullNameRecord;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                (Func<IServiceProvider, DateTimeOffset>)null!,
                _ => thirdValue,
                _ => fourthValue,
                _ => lastValue));

        Assert.Equal("second", ex.ParamName);
    }

    [Fact]
    public void WithFourResolvers_ThirdIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => PlusFifteenIdRefType);

        var secondValue = new object();
        var fourthValue = MinusFifteenIdSomeStringNameRecord;

        var lastValue = SomeTextStructType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => secondValue,
                (Func<IServiceProvider, string?>)null!,
                _ => fourthValue,
                _ => lastValue));

        Assert.Equal("third", ex.ParamName);
    }

    [Fact]
    public void WithFourResolvers_FourthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => EmptyString);

        var secondValue = SomeTextStructType;
        var thirdValue = PlusFifteenIdLowerSomeStringNameRecord;

        var lastValue = MinusFifteenIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => secondValue,
                _ => thirdValue,
                (Func<IServiceProvider, long?>)null!,
                _ => lastValue));

        Assert.Equal("fourth", ex.ParamName);
    }

    [Fact]
    public void WithFourResolvers_FifthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => ZeroIdRefType);

        var secondValue = DateTimeKind.Utc;
        var thirdValue = LowerSomeTextStructType;

        var fourthValue = PlusFifteenIdSomeStringNameRecord;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => secondValue,
                _ => thirdValue,
                _ => fourthValue,
                (Func<IServiceProvider, object>)null!));

        Assert.Equal("fifth", ex.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(MinusOne)]
    [InlineData(PlusFifteen)]
    public void WithFourResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        int? lastValue)
    {
        var sourceValue = MinusFifteenIdNullNameRecord;
        var source = Dependency.From(_ => sourceValue);

        var secondValue = SomeTextStructType;
        var thirdValue = false;

        var fourthValue = PlusFifteenIdRefType;

        var actual = source.With(_ => secondValue, _ => thirdValue, _ => fourthValue, _ => lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (sourceValue, secondValue, thirdValue, fourthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}
