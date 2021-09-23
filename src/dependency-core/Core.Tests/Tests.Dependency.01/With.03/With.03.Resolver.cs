using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class OneDependencyTest
{
    [Fact]
    public void WithTwoResolvers_SecondIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => PlusFifteenIdRefType);
        var lastValue = ZeroIdNullNameRecord;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                (Func<IServiceProvider, StructType>)null!,
                _ => lastValue));

        Assert.Equal("second", ex.ParamName);
    }

    [Fact]
    public void WithTwoResolvers_ThirdIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => MinusFifteenIdSomeStringNameRecord);
        var secondValue = LowerSomeTextStructType;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.With(
                _ => secondValue,
                (Func<IServiceProvider, RefType?>)null!));

        Assert.Equal("third", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void WithTwoResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
        StructType lastValue)
    {
        var sourceValue = ZeroIdRefType;
        var source = Dependency.From(_ => sourceValue);

        var secondValue = PlusFifteenIdLowerSomeStringNameRecord;

        var actual = source.With(_ => secondValue, _ => lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (sourceValue, secondValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}
