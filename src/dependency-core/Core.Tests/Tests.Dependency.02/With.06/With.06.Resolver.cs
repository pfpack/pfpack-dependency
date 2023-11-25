using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class TwoDependencyTest
{
    [Fact]
    public void WithFourResolvers_ThirdIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => int.MaxValue, _ => LowerSomeTextStructType);

        var fourthValue = PlusFifteenIdRefType;
        var fifthValue = new object();

        var lastValue = MinusFifteenIdSomeStringNameRecord;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                (Func<IServiceProvider, StructType?>)null!,
                _ => fourthValue,
                _ => fifthValue,
                _ => lastValue));

        Assert.Equal("third", ex.ParamName);
    }

    [Fact]
    public void WithFourResolvers_FourthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => SomeTextStructType, _ => MinusFifteenIdRefType);

        var thirdValue = SomeString;
        var fifthValue = PlusFifteenIdLowerSomeStringNameRecord;

        var lastValue = DateTimeKind.Utc;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => thirdValue,
                (Func<IServiceProvider, DateTime>)null!,
                _ => fifthValue,
                _ => lastValue));

        Assert.Equal("fourth", ex.ParamName);
    }

    [Fact]
    public void WithFourResolvers_FifthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => PlusFifteenIdSomeStringNameRecord, _ => decimal.MaxValue);

        var thirdValue = LowerSomeTextStructType;
        var fourthValue = ZeroIdRefType;

        var lastValue = true;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => thirdValue,
                _ => fourthValue,
                (Func<IServiceProvider, string?>)null!,
                _ => lastValue));

        Assert.Equal("fifth", ex.ParamName);
    }

    [Fact]
    public void WithFourResolvers_SixthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => SomeString, _ => MinusFifteenIdRefType);

        var thirdValue = PlusFifteen;
        var fourthValue = SomeTextStructType;

        var fifthValue = new { Name = LowerSomeString };

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => thirdValue,
                _ => fourthValue,
                _ => fifthValue,
                (Func<IServiceProvider, RecordType>)null!));

        Assert.Equal("sixth", ex.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    [InlineData(SomeString)]
    public void WithFourResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        string? lastValue)
    {
        var firstSource = PlusFifteenIdLowerSomeStringNameRecord;
        var secondSource = MinusFifteenIdRefType;

        var source = Dependency.From(_ => firstSource, _ => secondSource);

        var thirdValue = MinusOne;
        var fourthValue = true;

        var fifthValue = DateTimeKind.Unspecified;

        var actual = source.With(_ => thirdValue, _ => fourthValue, _ => fifthValue, _ => lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdValue, fourthValue, fifthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}