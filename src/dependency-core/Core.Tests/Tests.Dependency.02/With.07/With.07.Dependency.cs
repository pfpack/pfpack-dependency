using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class TwoDependencyTest
{
    [Fact]
    public void WithFiveDependency_OtherIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => MinusFifteenIdRefType, _ => Zero);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With<object?, StructType, RecordType, DateTimeKind, long?>(null!));

        Assert.Equal("other", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void WithFiveDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        StructType otherLast)
    {
        var firstSource = decimal.MaxValue;
        var secondSource = MinusFifteenIdSomeStringNameRecord;

        var source = Dependency.From(_ => firstSource, _ => secondSource);

        var otherFirst = ZeroIdRefType;
        var otherSecond = new { Id = PlusFifteen };

        var otherThird = MinusFifteenIdRefType;
        var otherFourth = DateTimeKind.Unspecified;

        var other = Dependency.From(_ => otherFirst, _ => otherSecond, _ => otherThird, _ => otherFourth, _ => otherLast);

        var actual = source.With(other);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, otherFirst, otherSecond, otherThird, otherFourth, otherLast);
        Assert.Equal(expectedValue, actualValue);
    }
}