#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void ToFirst_ExpectResolvedValueIsEqualToFirstSource(
            StructType firstSource)
        {
            var source = Dependency.Create(
                _ => firstSource,
                _ => MinusFifteenIdNullNameRecord,
                _ => PlusFifteen,
                _ => DateTimeKind.Unspecified,
                _ => MinusFifteenIdRefType,
                _ => UpperSomeString);

            var actual = source.ToFirst();
            var actualValue = actual.Resolve();

            Assert.Equal(firstSource, actualValue);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(TabString)]
        [InlineData(LowerSomeString)]
        [InlineData(SomeString)]
        public void ToSecond_ExpectResolvedValueIsEqualToSecondSource(
            string? secondSource)
        {
            var source = Dependency.Create(
                _ => SomeTextStructType,
                _ => secondSource,
                _ => MinusFifteenIdRefType,
                _ => PlusFifteen,
                _ => ZeroIdNullNameRecord,
                _ => long.MaxValue);

            var actual = source.ToSecond();
            var actualValue = actual.Resolve();

            Assert.Equal(secondSource, actualValue);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(MinusFifteen)]
        [InlineData(Zero)]
        [InlineData(PlusFifteen)]
        public void ToThird_ExpectResolvedValueIsEqualToThirdSource(
            int? thirdSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdNullNameRecord,
                _ => PlusFifteen,
                _ => thirdSource,
                _ => LowerSomeTextStructType,
                _ => WhiteSpaceString,
                _ => MinusFifteenIdRefType);

            var actual = source.ToThird();

            var actualValue = actual.Resolve();
            Assert.Equal(thirdSource, actualValue);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void ToFourth_ExpectResolvedValueIsEqualToFourthSource(
            RefType? fourthSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteen,
                _ => SomeString,
                _ => PlusFifteenIdRefType,
                _ => fourthSource,
                _ => new object(),
                _ => DateTimeKind.Utc);

            var actual = source.ToFourth();

            var actualValue = actual.Resolve();
            Assert.Equal(fourthSource, actualValue);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void ToFifth_ExpectResolvedValueIsEqualToFifthSource(
            RecordType? fifthSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdRefType,
                _ => new object(),
                _ => SomeTextStructType,
                _ => MinusFifteen,
                _ => fifthSource,
                _ => ZeroIdRefType);

            var actual = source.ToFifth();

            var actualValue = actual.Resolve();
            Assert.Equal(fifthSource, actualValue);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void ToSixth_ExpectResolvedValueIsEqualToSixthSource(
            StructType sixthSource)
        {
            var source = Dependency.Create(
                _ => SomeTextStructType,
                _ => MinusFifteen,
                _ => LowerSomeString,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => ZeroIdRefType,
                _ => sixthSource);

            var actual = source.ToSixth();

            var actualValue = actual.Resolve();
            Assert.Equal(sixthSource, actualValue);
        }
    }
}