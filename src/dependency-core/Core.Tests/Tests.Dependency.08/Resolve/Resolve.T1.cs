using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFirst_ExpectResolvedValueIsEqualToFirstSourceValue(
            IServiceProvider serviceProvider)
        {
            var first = new { Name = UpperSomeString };

            var dependency = Dependency.From(
                _ => first,
                _ => false,
                _ => long.MinValue,
                _ => MinusFifteenIdRefType,
                _ => ZeroIdNullNameRecord,
                _ => DateTimeKind.Local,
                _ => byte.MaxValue,
                _ => LowerSomeTextStructType);

            var actual = dependency.ResolveFirst(serviceProvider);
            Assert.Equal(first, actual);
        }
    }
}