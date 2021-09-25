using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class TwoDependencyTest
{
    [Fact]
    public void WithSixDependency_OtherIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => MinusFifteenIdSomeStringNameRecord, _ => long.MaxValue);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With<string?, bool, object, RefType?, DateTimeOffset, decimal>(null!));

        Assert.Equal("other", ex.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(false)]
    [InlineData(true)]
    public void WithSixDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        bool? otherLast)
    {
        var firstSource = decimal.MaxValue;
        var secondSource = MinusFifteenIdSomeStringNameRecord;

        var source = Dependency.From(_ => firstSource, _ => secondSource);

        var otherFirst = new Tuple<int, string, bool?>(int.MaxValue, EmptyString, true);
        var otherSecond = TwoWhiteSpacesString;

        var otherThird = PlusFifteenIdRefType;
        var otherFourth = new object();

        var otherFifth = SomeTextStructType;

        var other = Dependency.From(
            _ => otherFirst, _ => otherSecond, _ => otherThird, _ => otherFourth, _ => otherFifth, _ => otherLast);

        var actual = source.With(other);
        var actualValue = actual.Resolve();

        var expectedValue = ((firstSource, secondSource, otherFirst, otherSecond), (otherThird, otherFourth, otherFifth, otherLast));
        Assert.Equal(expectedValue, actualValue);
    }
}
