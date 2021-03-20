#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveSixth_ExpectResolvedValueIsEqualToSixthSourceValue(
            IServiceProvider serviceProvider)
        {
            var sixth = new Tuple<long, string?>(long.MinValue, EmptyString);

            var dependency = Dependency.Create(
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => (true, UpperSomeString),
                _ => new { Id = One },
                _ => ZeroIdRefType,
                _ => SomeTextStructType,
                _ => sixth,
                _ => MinusFifteen,
                _ => DateTimeKind.Local);

            var actual = dependency.ResolveSixth(serviceProvider);
            Assert.Equal(sixth, actual);
        }
    }
}