using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class EightDependencyTest
{
    [Theory]
    [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
    public void ResolveThird_ExpectResolvedValueIsEqualToThirdSourceValue(
        IServiceProvider serviceProvider)
    {
        var third = (StructType?)SomeTextStructType;

        var dependency = Dependency.From(
            _ => Zero,
            _ => DateTimeKind.Unspecified,
            _ => third,
            _ => new[] { byte.MaxValue },
            _ => decimal.MaxValue,
            _ => MinusFifteenIdNullNameRecord,
            _ => long.MinValue,
            _ => PlusFifteenIdRefType);

        var actual = dependency.ResolveThird(serviceProvider);
        Assert.Equal(third, actual);
    }
}