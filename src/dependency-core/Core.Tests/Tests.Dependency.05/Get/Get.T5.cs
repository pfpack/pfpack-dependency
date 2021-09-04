using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void GetFifth_ExpectResolvedValueIsEqualToFifthSource(
            RefType fifthSource)
        {
            var source = Dependency.Create(
                _ => SomeString,
                _ => decimal.MaxValue,
                _ => new { Name = UpperSomeString },
                _ => ZeroIdNullNameRecord,
                _ => fifthSource);

            var actual = source.GetFifth();

            var actualValue = actual.Resolve();
            Assert.Equal(fifthSource, actualValue);
        }
    }
}