using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class EightDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void GetFirst_ExpectResolvedValueIsEqualToFirstSource(
        StructType firstSource)
    {
        var source = Dependency.From(
            _ => firstSource,
            _ => new object(),
            _ => long.MaxValue,
            _ => DateTimeKind.Utc,
            _ => PlusFifteenIdRefType,
            _ => EmptyString,
            _ => new Tuple<bool, byte>(false, byte.MaxValue),
            _ => MinusFifteenIdSomeStringNameRecord);

        var actual = source.GetFirst();
        var actualValue = actual.Resolve();

        Assert.Equal(firstSource, actualValue);
    }
}