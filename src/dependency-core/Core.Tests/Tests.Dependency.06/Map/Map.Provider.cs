using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Fact]
        public void MapWithProvider_MapFirstFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => ZeroIdRefType,
                _ => MinusFifteen,
                _ => long.MinValue,
                _ => MinusFifteenIdRefType,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => LowerSomeTextStructType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (Func<IServiceProvider, RefType, string?>)null!,
                    (_, _) => SomeString,
                    (_, _) => PlusFifteenIdSomeStringNameRecord,
                    (_, _) => int.MaxValue,
                    (_, _) => decimal.One,
                    (_, _) => MinusFifteenIdSomeStringNameRecord));
            
            Assert.Equal("mapFirst", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapSecondFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => ZeroIdRefType,
                _ => SomeTextStructType,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => MinusFifteen,
                _ => new object(),
                _ => MinusFifteenIdNullNameRecord);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => int.MinValue,
                    (Func<IServiceProvider, StructType, int>)null!,
                    (_, _) => LowerSomeTextStructType,
                    (_, _) => WhiteSpaceString,
                    (_, _) => MinusFifteenIdRefType,
                    (_, _) => PlusFifteenIdLowerSomeStringNameRecord));
            
            Assert.Equal("mapSecond", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapThirdFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => new { Id = PlusFifteen },
                _ => DateTimeKind.Local,
                _ => MinusFifteenIdRefType,
                _ => PlusFifteenIdRefType,
                _ => LowerSomeTextStructType,
                _ => ZeroIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => MinusFifteenIdRefType,
                    (_, _) => PlusFifteenIdSomeStringNameRecord,
                    (Func<IServiceProvider, RefType?, RecordType?>)null!,
                    (_, _) => ZeroIdNullNameRecord,
                    (_, _) => new { Text = UpperSomeString },
                    (_, _) => int.MaxValue));
            
            Assert.Equal("mapThird", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapFourthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => decimal.One,
                _ => SomeTextStructType,
                _ => LowerSomeTextStructType,
                _ => SomeString,
                _ => MinusFifteen,
                _ => DateTimeKind.Local);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => TabString,
                    (_, _) => MinusFifteenIdSomeStringNameRecord,
                    (_, _) => decimal.MaxValue,
                    (Func<IServiceProvider, string, DateTime>)null!,
                    (_, _) => LowerSomeString,
                    (_, _) => PlusFifteenIdRefType));
            
            Assert.Equal("mapFourth", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapFifthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => MinusFifteenIdNullNameRecord,
                _ => Zero,
                _ => MinusFifteenIdRefType,
                _ => PlusFifteen,
                _ => UpperSomeString,
                _ => ThreeWhiteSpacesString);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => SomeString,
                    (_, _) => ZeroIdRefType,
                    (_, _) => long.MinValue,
                    (_, _) => DateTimeKind.Unspecified,
                    (Func<IServiceProvider, string?, RecordType>)null!,
                    (_, _) => LowerSomeTextStructType));
            
            Assert.Equal("mapFifth", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapSixthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => UpperSomeString,
                _ => PlusFifteen,
                _ => MinusFifteenIdNullNameRecord,
                _ => LowerSomeTextStructType,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => MinusFifteenIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => new { Id = MinusFifteen },
                    (_, _) => SomeTextStructType,
                    (_, _) => MinusFifteenIdSomeStringNameRecord,
                    (_, _) => MinusFifteenIdRefType,
                    (_, _) => LowerSomeString,
                    (Func<IServiceProvider, RefType, long?>)null!));
            
            Assert.Equal("mapSixth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void MapWithProvider_MapFuncIsNotNull_ExpectResolvedValuesAreEqualToMapped(
            RecordType? mappedLast)
        {
            var source = Dependency.From(
                _ => long.MaxValue,
                _ => MinusFifteen,
                _ => LowerSomeString,
                _ => PlusFifteen,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => MinusFifteenIdRefType);

            var mappedFirst = decimal.One;
            var mappedSecond = ZeroIdNullNameRecord;
            var mappedThird = LowerSomeTextStructType;
            var mappedFourth = MinusFifteen;
            var mappedFifth = MinusFifteenIdRefType;

            var actual = source.Map(
                (_, _) => mappedFirst,
                (_, _) => mappedSecond,
                (_, _) => mappedThird,
                (_, _) => mappedFourth,
                (_, _) => mappedFifth,
                (_, _) => mappedLast);

            var actualValue = actual.Resolve();
            var expectedValue = (mappedFirst, mappedSecond, mappedThird, mappedFourth, mappedFifth, mappedLast);

            Assert.Equal(expectedValue, actualValue);
        }
    }
}