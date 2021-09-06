using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveSecond_ExpectResolvedValueIsEqualToSecondSourceValue(
            IServiceProvider serviceProvider)
        {
            var second = PlusFifteenIdLowerSomeStringNameRecord;

            var dependency = Dependency.Create(
                _ => DateTimeKind.Utc,
                _ => second,
                _ => MinusFifteenIdNullNameRecord,
                _ => LowerSomeString,
                _ => int.MaxValue,
                _ => decimal.One);

            var actual = dependency.ResolveSecond(serviceProvider);
            Assert.Equal(second, actual);
        }
    }
}