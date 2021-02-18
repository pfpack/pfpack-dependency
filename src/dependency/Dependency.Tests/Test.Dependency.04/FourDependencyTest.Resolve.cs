#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFirst_ExpectResolvedValueIsEqualToFirstSourceValue(
            IServiceProvider serviceProvider)
        {
            var first = SomeTextStructType;

            var dependency = Dependency.Create(
                _ => first,
                _ => MinusFifteenIdNullNameRecord,
                _ => UpperSomeString,
                _ => PlusFifteenIdRefType);

            var actual = dependency.ResolveFirst(serviceProvider);
            Assert.Equal(first, actual);
        }

        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveSecond_ExpectResolvedValueIsEqualToSecondSourceValue(
            IServiceProvider serviceProvider)
        {
            var second = new object();

            var dependency = Dependency.Create(
                _ => MinusFifteenIdNullNameRecord,
                _ => second,
                _ => PlusFifteenIdRefType,
                _ => LowerSomeTextStructType);

            var actual = dependency.ResolveSecond(serviceProvider);
            Assert.Equal(second, actual);
        }

        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveThird_ExpectResolvedValueIsEqualToThirdSourceValue(
            IServiceProvider serviceProvider)
        {
            var third = ZeroIdRefType;

            var dependency = Dependency.Create(
                _ => PlusFifteen,
                _ => SomeString,
                _ => third,
                _ => PlusFifteenIdLowerSomeStringNameRecord);

            var actual = dependency.ResolveThird(serviceProvider);
            Assert.Equal(third, actual);
        }

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