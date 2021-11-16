using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class TwoDependencyTest
{
    [Fact]
    public void WithTwoDependency_OtherIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => SomeTextStructType, _ => PlusFifteenIdRefType);

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With<RecordType?, DateTime>(null!));

        Assert.Equal("other", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void WithTwoDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        RefType otherLast)
    {
        var firstSource = ZeroIdNullNameRecord;
        var secondSource = SomeTextStructType;

        var source = Dependency.From(_ => firstSource, _ => secondSource);

        var otherFirst = PlusFifteenIdRefType;
        var other = Dependency.From(_ => otherFirst, _ => otherLast);

        var actual = source.With(other);
        var actualValue = actual.Resolve();

        var expectedValue = (firstSource, secondSource, otherFirst, otherLast);
        Assert.Equal(expectedValue, actualValue);
    }
}