using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFirst_ExpectResolvedValueIsEqualToFirstSourceValue(
            IServiceProvider serviceProvider)
        {
            var first = SomeTextStructType;
            var dependency = Dependency.Create(_ => first, _ => MinusFifteenIdNullNameRecord);

            var actual = dependency.ResolveFirst(serviceProvider);
            Assert.Equal(first, actual);
        }
    }
}