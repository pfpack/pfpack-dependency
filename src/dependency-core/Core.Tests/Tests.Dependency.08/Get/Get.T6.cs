using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void GetSixth_ExpectResolvedValueIsEqualToSixthSource(
            RefType? sixthSource)
        {
            var source = Dependency.Create(
                _ => Array.Empty<decimal>(),
                _ => UpperSomeString,
                _ => MinusOne,
                _ => long.MaxValue,
                _ => ZeroIdNullNameRecord,
                _ => sixthSource,
                _ => SomeTextStructType,
                _ => new object());

            var actual = source.GetSixth();
            var actualValue = actual.Resolve();

            Assert.Equal(sixthSource, actualValue);
        }
    }
}