using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFourth_ExpectResolvedValueIsEqualToFourthSourceValue(
            IServiceProvider serviceProvider)
        {
            var fourth = MinusFifteenIdNullNameRecord;

            var dependency = Dependency.From(
                _ => SomeTextStructType,
                _ => ZeroIdNullNameRecord,
                _ => PlusFifteen,
                _ => fourth,
                _ => decimal.MaxValue,
                _ => UpperSomeString);

            var actual = dependency.ResolveFourth(serviceProvider);
            Assert.Equal(fourth, actual);
        }
    }
}