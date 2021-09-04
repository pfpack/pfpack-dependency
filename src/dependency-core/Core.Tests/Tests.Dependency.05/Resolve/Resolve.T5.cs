using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFifth_ExpectResolvedValueIsEqualToFifthSourceValue(
            IServiceProvider serviceProvider)
        {
            var fifth = MinusFifteen;

            var dependency = Dependency.Create(
                _ => LowerSomeString,
                _ => PlusFifteenIdSomeStringNameRecord,
                _ => decimal.One,
                _ => PlusFifteenIdRefType,
                _ => fifth);

            var actual = dependency.ResolveFifth(serviceProvider);
            Assert.Equal(fifth, actual);
        }
    }
}