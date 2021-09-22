using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFifth_ExpectResolvedValueIsEqualToFifthSourceValue(
            IServiceProvider serviceProvider)
        {
            var fifth = true;

            var dependency = Dependency.From(
                _ => PlusFifteen,
                _ => new object(),
                _ => ZeroIdRefType,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => fifth,
                _ => decimal.MaxValue,
                _ => EmptyString,
                _ => LowerSomeTextStructType);

            var actual = dependency.ResolveFifth(serviceProvider);
            Assert.Equal(fifth, actual);
        }
    }
}