using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveSecond_ExpectResolvedValueIsEqualToSecondSourceValue(
            IServiceProvider serviceProvider)
        {
            var second = LowerSomeTextStructType;

            var dependency = Dependency.From(
                _ => new { Id = PlusFifteen },
                _ => second,
                _ => TabString,
                _ => MinusFifteenIdRefType,
                _ => PlusFifteenIdSomeStringNameRecord);

            var actual = dependency.ResolveSecond(serviceProvider);
            Assert.Equal(second, actual);
        }
    }
}