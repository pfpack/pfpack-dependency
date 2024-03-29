using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FourDependencyTest
{
    [Theory]
    [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
    public void ResolveSecond_ExpectResolvedValueIsEqualToSecondSourceValue(
        IServiceProvider serviceProvider)
    {
        var second = new object();

        var dependency = Dependency.From(
            _ => MinusFifteenIdNullNameRecord,
            _ => second,
            _ => PlusFifteenIdRefType,
            _ => LowerSomeTextStructType);

        var actual = dependency.ResolveSecond(serviceProvider);
        Assert.Equal(second, actual);
    }
}