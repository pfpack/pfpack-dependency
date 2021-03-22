#nullable enable

using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void GetFirst_ExpectResolvedValueIsEqualToFirstSource(
            RecordType firstSource)
        {
            var source = Dependency.Create(
                _ => firstSource, _ => MinusFifteenIdSomeStringNameRecord, _ => ZeroIdRefType, _ => PlusFifteen);

            var actual = source.GetFirst();
            var actualValue = actual.Resolve();

            Assert.Equal(firstSource, actualValue);
        }
    }
}