using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFourth_ExpectResolvedValueIsEqualToFourthSourceValue(
            IServiceProvider serviceProvider)
        {
            var fourth = byte.MaxValue;

            var dependency = Dependency.From(
                _ => MinusFifteen,
                _ => UpperSomeString,
                _ => SomeTextStructType,
                _ => fourth,
                _ => new object(),
                _ => PlusFifteenIdRefType,
                _ => ZeroIdNullNameRecord);

            var actual = dependency.ResolveFourth(serviceProvider);
            Assert.Equal(fourth, actual);
        }
    }
}