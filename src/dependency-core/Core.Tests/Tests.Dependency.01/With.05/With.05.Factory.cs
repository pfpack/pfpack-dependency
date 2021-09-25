using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class OneDependencyTest
{
    [Fact]
    public void WithFourFactories_SecondIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => SomeTextStructType);

        var thirdValue = MinusOne;
        var fourthValue = PlusFifteenIdRefType;

        var lastValue = DateTimeKind.Unspecified;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                (Func<RecordType?>)null!,
                () => thirdValue,
                () => fourthValue,
                () => lastValue));

        Assert.Equal("second", ex.ParamName);
    }

    [Fact]
    public void WithFourFactories_ThirdIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => false);

        var secondValue = MinusFifteenIdRefType;
        var fourthValue = new object();

        var lastValue = PlusFifteenIdSomeStringNameRecord;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => secondValue,
                (Func<StructType>)null!,
                () => fourthValue,
                () => lastValue));

        Assert.Equal("third", ex.ParamName);
    }

    [Fact]
    public void WithFourFactories_FourthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => One);

        var secondValue = ZeroIdRefType;
        var thirdValue = MinusFifteenIdSomeStringNameRecord;

        var lastValue = long.MaxValue;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => secondValue,
                () => thirdValue,
                (Func<string>)null!,
                () => lastValue));

        Assert.Equal("fourth", ex.ParamName);
    }

    [Fact]
    public void WithFourFactories_FifthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => ZeroIdNullNameRecord);

        var secondValue = SomeTextStructType;
        var thirdValue = PlusFifteenIdRefType;

        var fourthValue = true;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => secondValue,
                () => thirdValue,
                () => fourthValue,
                (Func<object>)null!));

        Assert.Equal("fifth", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void WithFourFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        RecordType lastValue)
    {
        var sourceValue = DateTimeKind.Utc;
        var source = Dependency.From(_ => sourceValue);

        var secondValue = MinusFifteenIdRefType;
        var thirdValue = LowerSomeTextStructType;

        var fourthValue = new { Value = decimal.One };

        var actual = source.With(() => secondValue, () => thirdValue, () => fourthValue, () => lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (sourceValue, secondValue, thirdValue, fourthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}
