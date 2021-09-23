using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class OneDependencyTest
{
    [Fact]
    public void WithFiveResolvers_SecondIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => SomeTextStructType);

        var thirdValue = ZeroIdNullNameRecord;
        var fourthValue = MinusOne;

        var fifthValue = PlusFifteenIdLowerSomeStringNameRecord;
        var lastValue = false;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                (Func<IServiceProvider, long?>)null!,
                _ => thirdValue,
                _ => fourthValue,
                _ => fifthValue,
                _ => lastValue));

        Assert.Equal("second", ex.ParamName);
    }

    [Fact]
    public void WithFiveResolvers_ThirdIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => MinusFifteenIdSomeStringNameRecord);

        var secondValue = ZeroIdRefType;
        var fourthValue = DateTimeKind.Utc;

        var fifthValue = true;
        var lastValue = LowerSomeTextStructType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => secondValue,
                (Func<IServiceProvider, string>)null!,
                _ => fourthValue,
                _ => fifthValue,
                _ => lastValue));

        Assert.Equal("third", ex.ParamName);
    }

    [Fact]
    public void WithFiveResolvers_FourthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => long.MaxValue);

        var secondValue = MinusFifteenIdRefType;
        var thirdValue = UpperSomeString;

        var fifthValue = DateTimeKind.Unspecified;
        var lastValue = LowerSomeTextStructType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => secondValue,
                _ => thirdValue,
                (Func<IServiceProvider, RecordType>)null!,
                _ => fifthValue,
                _ => lastValue));

        Assert.Equal("fourth", ex.ParamName);
    }

    [Fact]
    public void WithFiveResolvers_FifthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => SomeTextStructType);

        var secondValue = PlusFifteenIdSomeStringNameRecord;
        var thirdValue = new object();

        var fourthValue = MinusFifteenIdRefType;
        var lastValue = DateTimeKind.Unspecified;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => secondValue,
                _ => thirdValue,
                _ => fourthValue,
                (Func<IServiceProvider, DateTimeOffset>)null!,
                _ => lastValue));

        Assert.Equal("fifth", ex.ParamName);
    }

    [Fact]
    public void WithFiveResolvers_SixthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => SomeTextStructType);

        var secondValue = WhiteSpaceString;
        var thirdValue = MinusFifteenIdNullNameRecord;

        var fourthValue = PlusFifteen;
        var fifthValue = MinusFifteenIdRefType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => secondValue,
                _ => thirdValue,
                _ => fourthValue,
                _ => fifthValue,
                (Func<IServiceProvider, bool?>)null!));

        Assert.Equal("sixth", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void WithFiveResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        RefType lastValue)
    {
        var sourceValue = SomeTextStructType;
        var source = Dependency.From(_ => sourceValue);

        var secondValue = ZeroIdNullNameRecord;
        var thirdValue = new object();

        var fourthValue = decimal.MaxValue;
        var fifthValue = true;

        var actual = source.With(_ => secondValue, _ => thirdValue, _ => fourthValue, _ => fifthValue, _ => lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (sourceValue, secondValue, thirdValue, fourthValue, fifthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}
