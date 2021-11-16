using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class ThreeDependencyTest
{
    [Theory]
    [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
    public void ResolveSecond_ExpectResolvedValueIsEqualToSecondSourceValue(
        IServiceProvider serviceProvider)
    {
        var second = PlusFifteenIdRefType;

        var dependency = Dependency.From(
            _ => ZeroIdNullNameRecord,
            _ => second,
            _ => LowerSomeString);

        var actual = dependency.ResolveSecond(serviceProvider);
        Assert.Equal(second, actual);
    }
}