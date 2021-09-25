using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class EightDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void GetThird_ExpectResolvedValueIsEqualToThirdSource(
        RefType thirdSource)
    {
        var source = Dependency.From(
            _ => new Tuple<long, string>(long.MaxValue, ThreeWhiteSpacesString),
            _ => MinusFifteenIdNullNameRecord,
            _ => thirdSource,
            _ => new object(),
            _ => byte.MaxValue,
            _ => ZeroIdRefType,
            _ => DateTimeKind.Unspecified,
            _ => Array.Empty<DateTime>());

        var actual = source.GetThird();
        var actualValue = actual.Resolve();

        Assert.Equal(thirdSource, actualValue);
    }
}
