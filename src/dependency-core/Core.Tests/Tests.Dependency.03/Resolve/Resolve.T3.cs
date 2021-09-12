using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveThird_ExpectResolvedValueIsEqualToThirdSourceValue(
            IServiceProvider serviceProvider)
        {
            var third = LowerSomeTextStructType;

            var dependency = Dependency.From(
                _ => PlusFifteenIdRefType,
                _ => ZeroIdNullNameRecord,
                _ => third);

            var actual = dependency.ResolveThird(serviceProvider);
            Assert.Equal(third, actual);
        }
    }
}