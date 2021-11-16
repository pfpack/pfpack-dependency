using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class OneDependencyTest
{
    [Fact]
    public void WithFiveDependency_OtherIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => decimal.MinusOne);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With<int, DateTime, RecordType, RecordType?, string>(null!));

        Assert.Equal("other", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void WithFiveDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        RecordType? otherLast)
    {
        var sourceValue = MinusFifteenIdRefType;
        var source = Dependency.From(_ => sourceValue);

        var otherFirst = SomeTextStructType;
        var otherSecond = MinusFifteenIdNullNameRecord;

        var otherThird = PlusFifteen;
        var otherFourth = decimal.MaxValue;

        var other = Dependency.From(
            _ => otherFirst, _ => otherSecond, _ => otherThird, _ => otherFourth, _ => otherLast);

        var actual = source.With(other);
        var actualValue = actual.Resolve();

        var expectedValue = (sourceValue, otherFirst, otherSecond, otherThird, otherFourth, otherLast);
        Assert.Equal(expectedValue, actualValue);
    }
}