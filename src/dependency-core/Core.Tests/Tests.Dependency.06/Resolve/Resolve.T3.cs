using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class SixDependencyTest
{
    [Theory]
    [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
    public void ResolveThird_ExpectResolvedValueIsEqualToThirdSourceValue(
        IServiceProvider serviceProvider)
    {
        var third = new { Text = SomeString };

        var dependency = Dependency.From(
            _ => MinusFifteenIdRefType,
            _ => byte.MaxValue,
            _ => third,
            _ => PlusFifteenIdRefType,
            _ => LowerSomeTextStructType,
            _ => PlusFifteenIdLowerSomeStringNameRecord);

        var actual = dependency.ResolveThird(serviceProvider);
        Assert.Equal(third, actual);
    }
}