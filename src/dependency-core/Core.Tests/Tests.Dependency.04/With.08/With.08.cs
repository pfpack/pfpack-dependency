using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FourDependencyTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(EmptyString)]
    [InlineData(SomeString)]
    public void WithFour_ExpectResolvedValuesAreEqualToSourceAndOther(
        string? lastValue)
    {
        var firstSource = new[] { long.MaxValue };
        var secondSource = DateTimeKind.Utc;

        var thirdSource = false;
        var fourthSource = SomeTextStructType;

        var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource);

        var fifthValue = MinusFifteenIdSomeStringNameRecord;

        var sixthValue = PlusFifteenIdRefType;
        var seventhValue = new object();

        var actual = source.With(fifthValue, sixthValue, seventhValue, lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = ((firstSource, secondSource, thirdSource, fourthSource), (fifthValue, sixthValue, seventhValue, lastValue));
        Assert.Equal(expectedValue, actualValue);
    }
}