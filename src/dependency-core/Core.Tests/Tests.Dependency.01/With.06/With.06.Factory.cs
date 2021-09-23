using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class OneDependencyTest
{
    [Fact]
    public void WithFiveFactories_SecondIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => long.MinValue);

        var thirdValue = false;
        var fourthValue = SomeTextStructType;

        var fifthValue = new object();
        var lastValue = MinusFifteenIdSomeStringNameRecord;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                (Func<RefType>)null!,
                () => thirdValue,
                () => fourthValue,
                () => fifthValue,
                () => lastValue));

        Assert.Equal("second", ex.ParamName);
    }

    [Fact]
    public void WithFiveFactories_ThirdIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => MinusFifteenIdRefType);

        var secondValue = int.MaxValue;
        var fourthValue = new object();

        var fifthValue = PlusFifteenIdLowerSomeStringNameRecord;
        var lastValue = DateTimeKind.Local;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => secondValue,
                (Func<StructType?>)null!,
                () => fourthValue,
                () => fifthValue,
                () => lastValue));

        Assert.Equal("third", ex.ParamName);
    }

    [Fact]
    public void WithFiveFactories_FourthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => LowerSomeTextStructType);

        var secondValue = new object();
        var thirdValue = decimal.One;

        var fifthValue = PlusFifteenIdRefType;
        var lastValue = ZeroIdNullNameRecord;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => secondValue,
                () => thirdValue,
                (Func<DateTimeKind?>)null!,
                () => fifthValue,
                () => lastValue));

        Assert.Equal("fourth", ex.ParamName);
    }

    [Fact]
    public void WithFiveFactories_FifthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => new object());

        var secondValue = DateTimeKind.Unspecified;
        var thirdValue = ZeroIdRefType;

        var fourthValue = SomeTextStructType;
        var lastValue = false;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => secondValue,
                () => thirdValue,
                () => fourthValue,
                (Func<RecordType?>)null!,
                () => lastValue));

        Assert.Equal("fifth", ex.ParamName);
    }

    [Fact]
    public void WithFiveFactories_SixthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => MixedWhiteSpacesString);

        var secondValue = PlusFifteenIdRefType;
        var thirdValue = LowerSomeTextStructType;

        var fourthValue = ZeroIdNullNameRecord;
        var fifthValue = new object();

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => secondValue,
                () => thirdValue,
                () => fourthValue,
                () => fifthValue,
                (Func<byte[]>)null!));

        Assert.Equal("sixth", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void WithFiveFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        StructType lastValue)
    {
        var sourceValue = MinusFifteenIdNullNameRecord;
        var source = Dependency.From(_ => sourceValue);

        var secondValue = DateTimeKind.Utc;
        var thirdValue = MinusFifteenIdRefType;

        var fourthValue = (true, false);
        var fifthValue = decimal.MinusOne;

        var actual = source.With(() => secondValue, () => thirdValue, () => fourthValue, () => fifthValue, () => lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (sourceValue, secondValue, thirdValue, fourthValue, fifthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}
