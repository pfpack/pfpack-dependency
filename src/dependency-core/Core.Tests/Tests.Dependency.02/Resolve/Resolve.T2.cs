using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveSecond_ExpectResolvedValueIsEqualToSecondSourceValue(
            IServiceProvider serviceProvider)
        {
            var second = MinusFifteenIdRefType;
            var dependency = Dependency.Create(_ => PlusFifteen, _ => second);

            var actual = dependency.ResolveSecond(serviceProvider);
            Assert.Equal(second, actual);
        }
    }
}