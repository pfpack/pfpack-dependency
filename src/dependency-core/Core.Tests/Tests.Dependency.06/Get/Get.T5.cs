using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void GetFifth_ExpectResolvedValueIsEqualToFifthSource(
            RecordType? fifthSource)
        {
            var source = Dependency.From(
                _ => MinusFifteenIdRefType,
                _ => new object(),
                _ => SomeTextStructType,
                _ => MinusFifteen,
                _ => fifthSource,
                _ => ZeroIdRefType);

            var actual = source.GetFifth();

            var actualValue = actual.Resolve();
            Assert.Equal(fifthSource, actualValue);
        }
    }
}