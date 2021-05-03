#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Theory]
        [MemberData(nameof(ServiceProviderTestSource.NullableProviders), MemberType = typeof(ServiceProviderTestSource))]
        public void ResolveFirst_ExpectResolvedValueIsEqualToFirstSourceValue(
            IServiceProvider serviceProvider)
        {
            var first = MinusFifteenIdSomeStringNameRecord;

            var dependency = Dependency.Create(
                _ => first,
                _ => SomeTextStructType,
                _ => new { Value = decimal.One },
                _ => WhiteSpaceString,
                _ => MinusFifteen,
                _ => DateTimeKind.Local,
                _ => MinusFifteenIdRefType);

            var actual = dependency.ResolveFirst(serviceProvider);
            Assert.Equal(first, actual);
        }
    }
}