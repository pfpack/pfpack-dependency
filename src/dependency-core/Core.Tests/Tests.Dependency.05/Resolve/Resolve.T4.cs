using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class FiveDependencyTest
{
    [Theory]
    [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
    public void ResolveFourth_ExpectResolvedValueIsEqualToFourthSourceValue(
        IServiceProvider serviceProvider)
    {
        var fourth = ThreeWhiteSpacesString;

        var dependency = Dependency.From(
            _ => MinusFifteenIdSomeStringNameRecord,
            _ => PlusFifteenIdRefType,
            _ => SomeTextStructType,
            _ => fourth,
            _ => MinusFifteenIdRefType);

        var actual = dependency.ResolveFourth(serviceProvider);
        Assert.Equal(fourth, actual);
    }
}
