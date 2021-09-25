using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FourDependencyTest
{
    [Theory]
    [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
    public void ResolveFirst_ExpectResolvedValueIsEqualToFirstSourceValue(
        IServiceProvider serviceProvider)
    {
        var first = SomeTextStructType;

        var dependency = Dependency.From(
            _ => first,
            _ => MinusFifteenIdNullNameRecord,
            _ => UpperSomeString,
            _ => PlusFifteenIdRefType);

        var actual = dependency.ResolveFirst(serviceProvider);
        Assert.Equal(first, actual);
    }
}
