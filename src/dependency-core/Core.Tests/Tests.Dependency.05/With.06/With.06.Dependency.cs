using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FiveDependencyTest
{
    [Fact]
    public void WithOneDependency_OtherIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(
            _ => PlusFifteenIdLowerSomeStringNameRecord,
            _ => SomeTextStructType,
            _ => MinusFifteen,
            _ => decimal.One,
            _ => MinusFifteenIdRefType);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With((Dependency<string?>)null!));

        Assert.Equal("other", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void WithOneDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        RecordType otherValue)
    {
        var firstSource = UpperSomeString;
        var secondSource = LowerSomeTextStructType;
        var thirdSource = MinusFifteenIdRefType;
        var fourthSource = new object();
        var fifthSource = PlusFifteen;

        var source = Dependency.From(
            _ => firstSource,
            _ => secondSource,
            _ => thirdSource,
            _ => fourthSource,
            _ => fifthSource);

        var other = Dependency.From(_ => otherValue);

        var actual = source.With(other);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthSource, otherValue);
        Assert.Equal(expectedValue, actualValue);
    }
}