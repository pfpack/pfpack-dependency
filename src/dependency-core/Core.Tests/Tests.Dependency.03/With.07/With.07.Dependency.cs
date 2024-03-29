using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class ThreeDependencyTest
{
    [Fact]
    public void WithFourDependency_OtherIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => MinusFifteenIdRefType, _ => SomeTextStructType, _ => DateTimeKind.Utc);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With<string, RecordType?, object?, DateTime>(null!));

        Assert.Equal("other", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void WithFourDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        RecordType? otherLast)
    {
        var firstSource = MinusFifteen;
        var secondSource = PlusFifteenIdRefType;

        var thirdSource = LowerSomeTextStructType;
        var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource);

        var otherFirst = UpperSomeString;
        var otherSecond = decimal.MinusOne;

        var otherThird = new { Name = SomeString };
        var other = Dependency.From(_ => otherFirst, _ => otherSecond, _ => otherThird, _ => otherLast);

        var actual = source.With(other);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdSource, otherFirst, otherSecond, otherThird, otherLast);
        Assert.Equal(expectedValue, actualValue);
    }
}