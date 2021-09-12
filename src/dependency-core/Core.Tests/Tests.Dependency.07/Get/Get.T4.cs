using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void GetFourth_ExpectResolvedValueIsEqualToFourthSource(
            RecordType fourthSource)
        {
            var source = Dependency.From(
                _ => ThreeWhiteSpacesString,
                _ => PlusFifteenIdRefType,
                _ => new { Id = PlusFifteen },
                _ => fourthSource,
                _ => DateTimeKind.Unspecified,
                _ => SomeTextStructType,
                _ => true);

            var actual = source.GetFourth();

            var actualValue = actual.Resolve();
            Assert.Equal(fourthSource, actualValue);
        }
    }
}