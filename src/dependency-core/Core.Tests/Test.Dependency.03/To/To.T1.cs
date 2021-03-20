#nullable enable

using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void ToFirst_ExpectResolvedValueAreEqualToFirstSource(
            StructType firstSource)
        {
            var source = Dependency.Create(_ => firstSource, _ => SomeString, _ => PlusFifteenIdRefType);
            var actual = source.ToFirst();

            var actualValue = actual.Resolve();
            Assert.Equal(firstSource, actualValue);
        }
    }
}