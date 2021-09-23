using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class EightDependencyTest
{
    [Theory]
    [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
    public void ResolveRest_ExpectResolvedValueIsEqualToRestSourceValue(
        IServiceProvider serviceProvider)
    {
        var rest = (SomeString, PlusFifteen, false);

        var dependency = Dependency.From(
            _ => LowerSomeTextStructType,
            _ => new { Name = UpperSomeString },
            _ => MinusFifteenIdNullNameRecord,
            _ => decimal.One,
            _ => true,
            _ => ZeroIdRefType,
            _ => Array.Empty<DateTimeOffset>(),
            _ => rest);

        var actual = dependency.ResolveRest(serviceProvider);
        Assert.Equal(rest, actual);
    }
}
