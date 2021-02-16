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

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void ToSecond_ExpectResolvedValueIsEqualToSecondSource(
            RefType secondSource)
        {
            var source = Dependency.Create(_ => SomeString, _ => secondSource, _ => new object());
            var actual = source.ToSecond();

            var actualValue = actual.Resolve();
            Assert.Equal(secondSource, actualValue);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void ToThird_ExpectResolvedValueIsEqualToThirdSource(
            RecordType thirdSource)
        {
            var source = Dependency.Create(_ => LowerSomeTextStructType, _ => PlusFifteenIdRefType, _ => thirdSource);
            var actual = source.ToThird();

            var actualValue = actual.Resolve();
            Assert.Equal(thirdSource, actualValue);
        }
    }
}