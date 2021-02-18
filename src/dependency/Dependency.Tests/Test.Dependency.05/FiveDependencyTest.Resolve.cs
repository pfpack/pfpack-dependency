#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFirst_ExpectResolvedValueIsEqualToFirstSourceValue(
            IServiceProvider serviceProvider)
        {
            var first = MinusFifteenIdRefType;

            var dependency = Dependency.Create(
                _ => first,
                _ => SomeTextStructType,
                _ => ZeroIdNullNameRecord,
                _ => decimal.MinValue,
                _ => PlusFifteenIdLowerSomeStringNameRecord);

            var actual = dependency.ResolveFirst(serviceProvider);
            Assert.Equal(first, actual);
        }

        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveSecond_ExpectResolvedValueIsEqualToSecondSourceValue(
            IServiceProvider serviceProvider)
        {
            var second = LowerSomeTextStructType;

            var dependency = Dependency.Create(
                _ => new { Id = PlusFifteen },
                _ => second,
                _ => TabString,
                _ => MinusFifteenIdRefType,
                _ => PlusFifteenIdSomeStringNameRecord);

            var actual = dependency.ResolveSecond(serviceProvider);
            Assert.Equal(second, actual);
        }

        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveThird_ExpectResolvedValueIsEqualToThirdSourceValue(
            IServiceProvider serviceProvider)
        {
            var third = MinusFifteenIdNullNameRecord;

            var dependency = Dependency.Create(
                _ => decimal.MaxValue,
                _ => PlusFifteenIdRefType,
                _ => third,
                _ => SomeTextStructType,
                _ => MinusFifteen);

            var actual = dependency.ResolveThird(serviceProvider);
            Assert.Equal(third, actual);
        }

        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFourth_ExpectResolvedValueIsEqualToFourthSourceValue(
            IServiceProvider serviceProvider)
        {
            var fourth = ThreeWhiteSpacesString;

            var dependency = Dependency.Create(
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => PlusFifteenIdRefType,
                _ => SomeTextStructType,
                _ => fourth,
                _ => MinusFifteenIdRefType);

            var actual = dependency.ResolveFourth(serviceProvider);
            Assert.Equal(fourth, actual);
        }

        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFifth_ExpectResolvedValueIsEqualToFifthSourceValue(
            IServiceProvider serviceProvider)
        {
            var fifth = MinusFifteen;

            var dependency = Dependency.Create(
                _ => LowerSomeString,
                _ => PlusFifteenIdSomeStringNameRecord,
                _ => decimal.One,
                _ => PlusFifteenIdRefType,
                _ => fifth);

            var actual = dependency.ResolveFifth(serviceProvider);
            Assert.Equal(fifth, actual);
        }
    }
}