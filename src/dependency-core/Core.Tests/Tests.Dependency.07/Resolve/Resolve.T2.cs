using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class SevenDependencyTest
{
    [Theory]
    [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
    public void ResolveSecond_ExpectResolvedValueIsEqualToSecondSourceValue(
        IServiceProvider serviceProvider)
    {
        var second = new object();

        var dependency = Dependency.From(
            _ => SomeTextStructType,
            _ => second,
            _ => MinusFifteen,
            _ => PlusFifteenIdSomeStringNameRecord,
            _ => MinusFifteenIdRefType,
            _ => UpperSomeString,
            _ => decimal.MinusOne);

        var actual = dependency.ResolveSecond(serviceProvider);
        Assert.Equal(second, actual);
    }
}