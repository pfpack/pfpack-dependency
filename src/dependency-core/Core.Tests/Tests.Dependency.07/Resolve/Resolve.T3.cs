using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveThird_ExpectResolvedValueIsEqualToThirdSourceValue(
            IServiceProvider serviceProvider)
        {
            var third = LowerSomeTextStructType;

            var dependency = Dependency.From(
                _ => DateTimeKind.Utc,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => third,
                _ => byte.MaxValue,
                _ => PlusFifteenIdRefType,
                _ => WhiteSpaceString,
                _ => new object());

            var actual = dependency.ResolveThird(serviceProvider);
            Assert.Equal(third, actual);
        }
    }
}