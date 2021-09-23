using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FiveDependencyTest
{
    [Theory]
    [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
    public void ResolveThird_ExpectResolvedValueIsEqualToThirdSourceValue(
        IServiceProvider serviceProvider)
    {
        var third = MinusFifteenIdNullNameRecord;

        var dependency = Dependency.From(
            _ => decimal.MaxValue,
            _ => PlusFifteenIdRefType,
            _ => third,
            _ => SomeTextStructType,
            _ => MinusFifteen);

        var actual = dependency.ResolveThird(serviceProvider);
        Assert.Equal(third, actual);
    }
}
