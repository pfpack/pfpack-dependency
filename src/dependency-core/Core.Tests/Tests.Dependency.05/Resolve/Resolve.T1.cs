#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFirst_ExpectResolvedValueIsEqualToFirstSourceValue(
            IServiceProvider serviceProvider)
        {
            var first = MinusFifteenIdRefType;

            var dependency = Dependency.Create(
                _ => first,
                _ => SomeTextStructType,
                _ => ZeroIdNullNameRecord,
                _ => decimal.MinValue,
                _ => PlusFifteenIdLowerSomeStringNameRecord);

            var actual = dependency.ResolveFirst(serviceProvider);
            Assert.Equal(first, actual);
        }
    }
}