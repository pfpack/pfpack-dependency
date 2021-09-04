using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFifth_ExpectResolvedValueIsEqualToFifthSourceValue(
            IServiceProvider serviceProvider)
        {
            var fifth = ZeroIdNullNameRecord;

            var dependency = Dependency.Create(
                _ => MinusFifteen,
                _ => EmptyString,
                _ => MinusFifteenIdNullNameRecord,
                _ => NullTextStructType,
                _ => fifth,
                _ => PlusFifteenIdRefType);

            var actual = dependency.ResolveFifth(serviceProvider);
            Assert.Equal(fifth, actual);
        }
    }
}