#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFirst_ExpectResolvedValueIsEqualToFirstSourceValue(
            IServiceProvider serviceProvider)
        {
            var first = UpperSomeString;

            var dependency = Dependency.Create(
                _ => first,
                _ => ZeroIdRefType,
                _ => MinusFifteen,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => SomeTextStructType,
                _ => new object());

            var actual = dependency.ResolveFirst(serviceProvider);
            Assert.Equal(first, actual);
        }

        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveSecond_ExpectResolvedValueIsEqualToSecondSourceValue(
            IServiceProvider serviceProvider)
        {
            var second = PlusFifteenIdLowerSomeStringNameRecord;

            var dependency = Dependency.Create(
                _ => DateTimeKind.Utc,
                _ => second,
                _ => MinusFifteenIdNullNameRecord,
                _ => LowerSomeString,
                _ => int.MaxValue,
                _ => decimal.One);

            var actual = dependency.ResolveSecond(serviceProvider);
            Assert.Equal(second, actual);
        }

        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveThird_ExpectResolvedValueIsEqualToThirdSourceValue(
            IServiceProvider serviceProvider)
        {
            var third = new { Text = SomeString };

            var dependency = Dependency.Create(
                _ => MinusFifteenIdRefType,
                _ => byte.MaxValue,
                _ => third,
                _ => PlusFifteenIdRefType,
                _ => LowerSomeTextStructType,
                _ => PlusFifteenIdLowerSomeStringNameRecord);

            var actual = dependency.ResolveThird(serviceProvider);
            Assert.Equal(third, actual);
        }

        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFourth_ExpectResolvedValueIsEqualToFourthSourceValue(
            IServiceProvider serviceProvider)
        {
            var fourth = MinusFifteenIdNullNameRecord;

            var dependency = Dependency.Create(
                _ => SomeTextStructType,
                _ => ZeroIdNullNameRecord,
                _ => PlusFifteen,
                _ => fourth,
                _ => decimal.MaxValue,
                _ => UpperSomeString);

            var actual = dependency.ResolveFourth(serviceProvider);
            Assert.Equal(fourth, actual);
        }

        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFifth_ExpectResolvedValueIsEqualToFifthSourceValue(
            IServiceProvider serviceProvider)
        {
            var fifth = ZeroIdNullNameRecord;

            var dependency = Dependency.Create(
                _ => MinusFifteen,
                _ => EmptyString,
                _ => MinusFifteenIdNullNameRecord,
                _ => NullTextStructType,
                _ => fifth,
                _ => PlusFifteenIdRefType);

            var actual = dependency.ResolveFifth(serviceProvider);
            Assert.Equal(fifth, actual);
        }

        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveSixth_ExpectResolvedValueIsEqualToSixthSourceValue(
            IServiceProvider serviceProvider)
        {
            var sixth = DateTimeKind.Unspecified;

            var dependency = Dependency.Create(
                _ => SomeTextStructType,
                _ => MinusFifteenIdNullNameRecord,
                _ => PlusFifteenIdRefType,
                _ => decimal.MinusOne,
                _ => new object(),
                _ => sixth);

            var actual = dependency.ResolveSixth(serviceProvider);
            Assert.Equal(sixth, actual);
        }
    }
}