using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FiveDependencyTest
{
    [Fact]
    public void WithTwoDependency_OtherIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => LowerSomeString,
            _ => PlusFifteenIdRefType,
            _ => SomeTextStructType,
            _ => new object(),
            _ => ZeroIdNullNameRecord);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With<DateTimeOffset?, byte>(null!));

        Assert.Equal("other", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void WithTwoDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        StructType otherLast)
    {
        var firstSource = MinusFifteenIdSomeStringNameRecord;
        var secondSource = PlusFifteenIdLowerSomeStringNameRecord;
        var thirdSource = Zero;
        var fourthSource = DateTimeKind.Utc;
        var fifthSource = WhiteSpaceString;

        var source = Dependency.From(
            _ => firstSource,
            _ => secondSource,
            _ => thirdSource,
            _ => fourthSource,
            _ => fifthSource);

        var otherFirst = new { Id = MinusFifteen, Name = SomeString };
        var other = Dependency.From(_ => otherFirst, _ => otherLast);

        var actual = source.With(other);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthSource, otherFirst, otherLast);
        Assert.Equal(expectedValue, actualValue);
    }
}