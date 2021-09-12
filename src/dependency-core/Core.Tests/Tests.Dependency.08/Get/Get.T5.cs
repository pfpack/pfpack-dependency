using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void GetFifth_ExpectResolvedValueIsEqualToFifthSource(
            RecordType? fifthSource)
        {
            var source = Dependency.From(
                _ => new object(),
                _ => SomeTextStructType,
                _ => DateTimeKind.Local,
                _ => true,
                _ => fifthSource,
                _ => PlusFifteenIdRefType,
                _ => false,
                _ => new[] { byte.MinValue, byte.MaxValue, byte.MinValue });

            var actual = source.GetFifth();
            var actualValue = actual.Resolve();

            Assert.Equal(fifthSource, actualValue);
        }
    }
}