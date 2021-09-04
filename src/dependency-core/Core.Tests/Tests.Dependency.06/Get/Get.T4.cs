using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void GetFourth_ExpectResolvedValueIsEqualToFourthSource(
            RefType? fourthSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteen,
                _ => SomeString,
                _ => PlusFifteenIdRefType,
                _ => fourthSource,
                _ => new object(),
                _ => DateTimeKind.Utc);

            var actual = source.GetFourth();

            var actualValue = actual.Resolve();
            Assert.Equal(fourthSource, actualValue);
        }
    }
}