using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class OneDependencyTest
{
    [Fact]
    public void WithOneDependency_OtherIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => PlusFifteenIdRefType);
        Dependency<StructType> other = null!;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(other));

        Assert.Equal("other", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void WithOneDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        RefType? otherValue)
    {
        var sourceValue = MinusFifteenIdSomeStringNameRecord;
        var source = Dependency.From(_ => sourceValue);

        var other = Dependency.From(_ => otherValue);

        var actual = source.With(other);
        var actualValue = actual.Resolve();

        var expectedValue = (sourceValue, otherValue);
        Assert.Equal(expectedValue, actualValue);
    }
}