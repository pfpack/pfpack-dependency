using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FourDependencyTest
{
    [Fact]
    public void WithOneDependency_OtherIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => SomeTextStructType,
            _ => MinusFifteenIdSomeStringNameRecord,
            _ => SomeString,
            _ => PlusFifteenIdRefType);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With((Dependency<object>)null!));

        Assert.Equal("other", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void WithOneDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        StructType otherValue)
    {
        var firstSource = MinusFifteenIdNullNameRecord;
        var secondSource = ZeroIdRefType;
        var thirdSource = new { Id = PlusFifteen };
        var fourthSource = decimal.One;

        var source = Dependency.From(
            _ => firstSource,
            _ => secondSource,
            _ => thirdSource,
            _ => fourthSource);

        var other = Dependency.From(_ => otherValue);

        var actual = source.With(other);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, otherValue);
        Assert.Equal(expectedValue, actualValue);
    }
}
