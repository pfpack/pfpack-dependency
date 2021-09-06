using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveSixth_ExpectResolvedValueIsEqualToSixthSourceValue(
            IServiceProvider serviceProvider)
        {
            var sixth = new { Id = PlusFifteen, Text = UpperSomeString };

            var dependency = Dependency.Create(
                _ => MinusFifteenIdNullNameRecord,
                _ => PlusFifteenIdRefType,
                _ => decimal.MaxValue,
                _ => DateTimeKind.Utc,
                _ => MinusFifteen,
                _ => sixth,
                _ => int.MinValue);

            var actual = dependency.ResolveSixth(serviceProvider);
            Assert.Equal(sixth, actual);
        }
    }
}