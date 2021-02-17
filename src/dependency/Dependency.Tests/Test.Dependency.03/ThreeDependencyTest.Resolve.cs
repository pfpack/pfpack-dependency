#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFirst_ExpectResolvedValueIsEqualToFirstSourceValue(
            IServiceProvider serviceProvider)
        {
            var first = MinusFifteenIdNullNameRecord;

            var dependency = Dependency.Create(
                _ => first,
                _ => new { Name = SomeString },
                _ => SomeTextStructType);

            var actual = dependency.ResolveFirst(serviceProvider);
            Assert.Equal(first, actual);
        }

        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveSecond_ExpectResolvedValueIsEqualToSecondSourceValue(
            IServiceProvider serviceProvider)
        {
            var second = PlusFifteenIdRefType;

            var dependency = Dependency.Create(
                _ => ZeroIdNullNameRecord,
                _ => second,
                _ => LowerSomeString);

            var actual = dependency.ResolveSecond(serviceProvider);
            Assert.Equal(second, actual);
        }

        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveThird_ExpectResolvedValueIsEqualToThirdSourceValue(
            IServiceProvider serviceProvider)
        {
            var third = LowerSomeTextStructType;

            var dependency = Dependency.Create(
                _ => PlusFifteenIdRefType,
                _ => ZeroIdNullNameRecord,
                _ => third);

            var actual = dependency.ResolveThird(serviceProvider);
            Assert.Equal(third, actual);
        }
    }
}