using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FiveDependencyTest
{
    [Fact]
    public void WithThreeFactories_SixthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => new object(),
            _ => DateTimeKind.Utc,
            _ => PlusFifteenIdLowerSomeStringNameRecord,
            _ => decimal.MaxValue,
            _ => WhiteSpaceString);

        var seventhValue = MinusFifteenIdRefType;
        var restValue = SomeTextStructType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                (Func<long>)null!,
                () => seventhValue,
                () => restValue));

        Assert.Equal("sixth", ex.ParamName);
    }

    [Fact]
    public void WithThreeFactories_SeventhIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => false,
            _ => MinusFifteenIdSomeStringNameRecord,
            _ => byte.MaxValue,
            _ => MixedWhiteSpacesString,
            _ => new { Value = decimal.MaxValue });

        var sixthValue = DateTimeKind.Unspecified;
        var restValue = LowerSomeTextStructType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => sixthValue,
                (Func<RefType>)null!,
                () => restValue));

        Assert.Equal("seventh", ex.ParamName);
    }

    [Fact]
    public void WithThreeFactories_RestIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => Zero,
            _ => PlusFifteenIdRefType,
            _ => Array.Empty<string>(),
            _ => SomeTextStructType,
            _ => DateTimeKind.Local);

        var sixthValue = WhiteSpaceString;
        var seventhValue = long.MinValue;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                () => sixthValue,
                () => seventhValue,
                (Func<RecordType?>)null!));

        Assert.Equal("rest", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void WithThreeFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        StructType lastValue)
    {
        var firstSource = ZeroIdNullNameRecord;
        var secondSource = default(string);

        var thirdSource = decimal.MaxValue;
        var fourthSource = DateTimeKind.Utc;

        var fifthSource = new[] { byte.MaxValue };

        var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource);

        var sixthValue = true;
        var seventhValue = PlusFifteenIdRefType;

        var actual = source.With(() => sixthValue, () => seventhValue, () => lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = ((firstSource, secondSource, thirdSource, fourthSource), (fifthSource, sixthValue, seventhValue, lastValue));
        Assert.Equal(expectedValue, actualValue);
    }
}
