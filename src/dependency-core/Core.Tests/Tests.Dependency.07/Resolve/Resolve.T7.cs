using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveSeventh_ExpectResolvedValueIsEqualToSeventhSourceValue(
            IServiceProvider serviceProvider)
        {
            var seventh = PlusFifteenIdRefType;

            var dependency = Dependency.Create(
                _ => SomeTextStructType,
                _ => new object(),
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => long.MaxValue,
                _ => DateTimeKind.Unspecified,
                _ => decimal.MinusOne,
                _ => seventh);

            var actual = dependency.ResolveSeventh(serviceProvider);
            Assert.Equal(seventh, actual);
        }
    }
}