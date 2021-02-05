#nullable enable

using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void ToFirst_ExpectResolvedValueAreSameAsFirstSource(
            RefType? firstSource)
        {
            var source = Dependency.Create(
                _ => firstSource,
                _ => SomeTextStructType,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => (string?)null,
                _ => new object());

            var actual = source.ToFirst();
            var actualValue = actual.Resolve();

            Assert.Equal(firstSource, actualValue);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void ToSecond_ExpectResolvedValueAreSameAsSecondSource(
            RecordType secondSource)
        {
            var source = Dependency.Create(
                _ => ZeroIdNullNameRecord,
                _ => secondSource,
                _ => MinusFifteen,
                _ => decimal.One,
                _ => PlusFifteenIdRefType);

            var actual = source.ToSecond();
            var actualValue = actual.Resolve();

            Assert.Equal(secondSource, actualValue);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void ToThird_ExpectResolvedValueAreSameAsThirdSource(
            RecordType? thirdSource)
        {
            var source = Dependency.Create(
                _ => UpperSomeString,
                _ => SomeTextStructType,
                _ => thirdSource,
                _ => new object(),
                _ => MinusFifteenIdRefType);

            var actual = source.ToThird();

            var actualValue = actual.Resolve();
            Assert.Equal(thirdSource, actualValue);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void ToFourth_ExpectResolvedValueAreSameAsFourthSource(
            StructType fourthSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => MinusFifteen,
                _ => EmptyString,
                _ => fourthSource,
                _ => ZeroIdRefType);

            var actual = source.ToFourth();

            var actualValue = actual.Resolve();
            Assert.Equal(fourthSource, actualValue);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void ToFifth_ExpectResolvedValueAreSameAsFifthSource(
            RefType fifthSource)
        {
            var source = Dependency.Create(
                _ => SomeString,
                _ => decimal.MaxValue,
                _ => new { Name = UpperSomeString },
                _ => ZeroIdNullNameRecord,
                _ => fifthSource);

            var actual = source.ToFifth();

            var actualValue = actual.Resolve();
            Assert.Equal(fifthSource, actualValue);
        }
    }
}