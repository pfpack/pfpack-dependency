#nullable enable

using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void GetSixth_ExpectResolvedValueIsEqualToSixthSource(
            StructType sixthSource)
        {
            var source = Dependency.Create(
                _ => SomeTextStructType,
                _ => MinusFifteen,
                _ => LowerSomeString,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => ZeroIdRefType,
                _ => sixthSource);

            var actual = source.GetSixth();

            var actualValue = actual.Resolve();
            Assert.Equal(sixthSource, actualValue);
        }
    }
}