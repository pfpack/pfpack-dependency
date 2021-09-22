using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFourth_ExpectResolvedValueIsEqualToFourthSourceValue(
            IServiceProvider serviceProvider)
        {
            var fourth = PlusFifteenIdLowerSomeStringNameRecord;

            var dependency = Dependency.From(
                _ => new Tuple<int, bool>(MinusOne, true),
                _ => MinusFifteenIdRefType,
                _ => long.MinValue,
                _ => fourth,
                _ => Array.Empty<long>(),
                _ => SomeTextStructType,
                _ => new object(),
                _ => PlusFifteen);

            var actual = dependency.ResolveFourth(serviceProvider);
            Assert.Equal(fourth, actual);
        }
    }
}