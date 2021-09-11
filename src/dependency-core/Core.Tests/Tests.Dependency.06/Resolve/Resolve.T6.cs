using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveSixth_ExpectResolvedValueIsEqualToSixthSourceValue(
            IServiceProvider serviceProvider)
        {
            var sixth = DateTimeKind.Unspecified;

            var dependency = Dependency.From(
                _ => SomeTextStructType,
                _ => MinusFifteenIdNullNameRecord,
                _ => PlusFifteenIdRefType,
                _ => decimal.MinusOne,
                _ => new object(),
                _ => sixth);

            var actual = dependency.ResolveSixth(serviceProvider);
            Assert.Equal(sixth, actual);
        }
    }
}