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
        public void ToFourth_ExpectResolvedValueIsEqualToFourthSource(
            RecordType? fourthSource)
        {
            var source = Dependency.Create(
                _ => int.MaxValue, _ => ZeroIdRefType, _ => new object(), _ => fourthSource);

            var actual = source.ToFourth();

            var actualValue = actual.Resolve();
            Assert.Equal(fourthSource, actualValue);
        }
    }
}