using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFourth_ExpectResolvedValueIsEqualToFourthSourceValue(
            IServiceProvider serviceProvider)
        {
            var fourth = MinusFifteenIdSomeStringNameRecord;

            var dependency = Dependency.Create(
                _ => SomeTextStructType,
                _ => WhiteSpaceString,
                _ => PlusFifteenIdRefType,
                _ => fourth);

            var actual = dependency.ResolveFourth(serviceProvider);
            Assert.Equal(fourth, actual);
        }
    }
}