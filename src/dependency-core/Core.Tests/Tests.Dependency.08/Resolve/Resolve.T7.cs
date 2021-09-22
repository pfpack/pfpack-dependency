using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveSeventh_ExpectResolvedValueIsEqualToSeventhSourceValue(
            IServiceProvider serviceProvider)
        {
            var seventh = UpperSomeString;

            var dependency = Dependency.From(
                _ => new object(),
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => Zero,
                _ => LowerSomeTextStructType,
                _ => PlusFifteenIdRefType,
                _ => DateTimeKind.Utc,
                _ => seventh,
                _ => long.MinValue);

            var actual = dependency.ResolveSeventh(serviceProvider);
            Assert.Equal(seventh, actual);
        }
    }
}