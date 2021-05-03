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
        public void ResolveSecond_ExpectResolvedValueIsEqualToSecondSourceValue(
            IServiceProvider serviceProvider)
        {
            var second = PlusFifteenIdRefType;

            var dependency = Dependency.Create(
                _ => decimal.MaxValue,
                _ => second,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => true,
                _ => SomeTextStructType,
                _ => new object(),
                _ => new Tuple<string, int>(WhiteSpaceString, PlusFifteen),
                _ => DateTimeKind.Utc);

            var actual = dependency.ResolveSecond(serviceProvider);
            Assert.Equal(second, actual);
        }
    }
}