using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void GetFirst_ExpectResolvedValueIsEqualToFirstSource(
            RefType? firstSource)
        {
            var source = Dependency.Create(
                _ => firstSource,
                _ => SomeTextStructType,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => (string?)null,
                _ => new object());

            var actual = source.GetFirst();
            var actualValue = actual.Resolve();

            Assert.Equal(firstSource, actualValue);
        }
    }
}