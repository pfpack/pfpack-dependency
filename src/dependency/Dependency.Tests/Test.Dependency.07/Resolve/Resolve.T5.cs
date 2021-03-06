#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFifth_ExpectResolvedValueIsEqualToFifthSourceValue(
            IServiceProvider serviceProvider)
        {
            var fifth = DateTimeKind.Local;

            var dependency = Dependency.Create(
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => LowerSomeTextStructType,
                _ => new { Id = PlusFifteen },
                _ => byte.MaxValue,
                _ => fifth,
                _ => MinusFifteenIdRefType,
                _ => decimal.MinValue);

            var actual = dependency.ResolveFifth(serviceProvider);
            Assert.Equal(fifth, actual);
        }
    }
}