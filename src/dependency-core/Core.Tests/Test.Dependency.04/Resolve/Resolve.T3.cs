#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveThird_ExpectResolvedValueIsEqualToThirdSourceValue(
            IServiceProvider serviceProvider)
        {
            var third = ZeroIdRefType;

            var dependency = Dependency.Create(
                _ => PlusFifteen,
                _ => SomeString,
                _ => third,
                _ => PlusFifteenIdLowerSomeStringNameRecord);

            var actual = dependency.ResolveThird(serviceProvider);
            Assert.Equal(third, actual);
        }
    }
}