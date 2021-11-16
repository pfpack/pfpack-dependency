using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FiveDependencyTest
{
    [Fact]
    public void WithOneFactory_SixthIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => new object(),
            _ => MinusFifteenIdSomeStringNameRecord,
            _ => LowerSomeTextStructType,
            _ => decimal.MinusOne,
            _ => long.MaxValue);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With((Func<RefType?>)null!));

        Assert.Equal("sixth", ex.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(DateTimeKind.Local)]
    [InlineData(DateTimeKind.Unspecified)]
    [InlineData(DateTimeKind.Utc)]
    public void WithOneFactory_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        DateTimeKind? sixthValue)
    {
        var firstSource = PlusFifteenIdRefType;
        var secondSource = new { Value = decimal.MaxValue };

        var thirdSource = SomeTextStructType;
        var fourthSource = ZeroIdNullNameRecord;

        var fifthSource = long.MinValue;

        var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource);

        var actual = source.With(() => sixthValue);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthSource, sixthValue);
        Assert.Equal(expectedValue, actualValue);
    }
}