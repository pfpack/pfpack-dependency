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

            var dependency = Dependency.From(
                _ => first,
                _ => ZeroIdRefType,
                _ => MinusFifteen,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => SomeTextStructType,
                _ => new object());

            var actual = dependency.ResolveFirst(serviceProvider);
            Assert.Equal(first, actual);
        }
    }
}