using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void Resolve_ExpectResolvedValueIsEqualToSourceValue(
            IServiceProvider serviceProvider)
        {
            var source = PlusFifteenIdLowerSomeStringNameRecord;
            var dependency = Dependency.From(_ => source);

            var actual = dependency.Resolve(serviceProvider);
            Assert.Equal(source, actual);
        }
    }
}