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
        public void ToFirst_ExpectResolvedValueIsEqualToFirstSource(
            RecordType firstSource)
        {
            var source = Dependency.Create(
                _ => firstSource, _ => MinusFifteenIdSomeStringNameRecord, _ => ZeroIdRefType, _ => PlusFifteen);

            var actual = source.ToFirst();
            var actualValue = actual.Resolve();

            Assert.Equal(firstSource, actualValue);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void ToSecond_ExpectResolvedValueIsEqualToSecondSource(
            StructType secondSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteen, _ => secondSource, _ => PlusFifteenIdRefType, _ => ZeroIdNullNameRecord);

            var actual = source.ToSecond();
            var actualValue = actual.Resolve();

            Assert.Equal(secondSource, actualValue);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void ToThird_ExpectResolvedValueIsEqualToThirdSource(
            RefType? thirdSource)
        {
            var source = Dependency.Create(
                _ => default(StructType?), _ => MinusFifteenIdSomeStringNameRecord, _ => thirdSource, _ => ZeroIdRefType);

            var actual = source.ToThird();

            var actualValue = actual.Resolve();
            Assert.Equal(thirdSource, actualValue);
        }

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