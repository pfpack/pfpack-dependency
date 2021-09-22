using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Fact]
        public void Map_MapFirstFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => MinusFifteenIdNullNameRecord,
                _ => LowerSomeTextStructType,
                _ => SomeString,
                _ => PlusFifteenIdRefType,
                _ => decimal.MinusOne,
                _ => new { Name = SomeString });

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (Func<RecordType?, StructType>)null!,
                    _ => new object(),
                    _ => MinusFifteenIdSomeStringNameRecord,
                    _ => PlusFifteenIdRefType,
                    _ => UpperSomeString,
                    _ => PlusFifteenIdSomeStringNameRecord));
            
            Assert.Equal("mapFirst", ex.ParamName);
        }

        [Fact]
        public void Map_MapSecondFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => ZeroIdRefType,
                _ => decimal.MinValue,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => MinusFifteen,
                _ => SomeTextStructType,
                _ => MinusFifteenIdNullNameRecord);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => DateTimeKind.Utc,
                    (Func<decimal, RefType?>)null!,
                    _ => LowerSomeTextStructType,
                    _ => WhiteSpaceString,
                    _ => MinusFifteenIdRefType,
                    _ => ZeroIdNullNameRecord));
            
            Assert.Equal("mapSecond", ex.ParamName);
        }

        [Fact]
        public void Map_MapThirdFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => SomeTextStructType,
                _ => long.MinValue,
                _ => new object(),
                _ => PlusFifteenIdRefType,
                _ => PlusFifteenIdSomeStringNameRecord,
                _ => ZeroIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => MinusFifteenIdRefType,
                    _ => PlusFifteenIdSomeStringNameRecord,
                    (Func<object, string>)null!,
                    _ => ZeroIdNullNameRecord,
                    _ => new { Text = UpperSomeString },
                    _ => decimal.MinusOne));
            
            Assert.Equal("mapThird", ex.ParamName);
        }

        [Fact]
        public void Map_MapFourthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => long.MaxValue,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => LowerSomeTextStructType,
                _ => MinusFifteen,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => DateTimeKind.Local);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => TabString,
                    _ => ZeroIdRefType,
                    _ => PlusFifteen,
                    (Func<int, RecordType>)null!,
                    _ => LowerSomeString,
                    _ => MinusFifteenIdNullNameRecord));
            
            Assert.Equal("mapFourth", ex.ParamName);
        }

        [Fact]
        public void Map_MapFifthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => MinusFifteenIdNullNameRecord,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => ZeroIdRefType,
                _ => PlusFifteen,
                _ => LowerSomeTextStructType,
                _ => ThreeWhiteSpacesString);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => SomeString,
                    _ => ZeroIdRefType,
                    _ => long.MinValue,
                    _ => DateTimeKind.Unspecified,
                    (Func<StructType, DateTimeOffset>)null!,
                    _ => decimal.One));
            
            Assert.Equal("mapFifth", ex.ParamName);
        }

        [Fact]
        public void Map_MapSixthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => UpperSomeString,
                _ => MinusFifteenIdRefType,
                _ => PlusFifteen,
                _ => LowerSomeTextStructType,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => decimal.MinValue);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => new { Name = WhiteSpaceString },
                    _ => SomeTextStructType,
                    _ => ZeroIdRefType,
                    _ => MinusFifteenIdNullNameRecord,
                    _ => LowerSomeString,
                    (Func<decimal, RecordType?>)null!));
            
            Assert.Equal("mapSixth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void Map_MapFuncIsNotNull_ExpectResolvedValuesAreEqualToMapped(
            StructType mappedLast)
        {
            var source = Dependency.From(
                _ => DateTimeKind.Local,
                _ => new object(),
                _ => SomeTextStructType,
                _ => PlusFifteen,
                _ => LowerSomeString,
                _ => MinusFifteenIdSomeStringNameRecord);

            var mappedFirst = PlusFifteenIdRefType;
            var mappedSecond = ZeroIdNullNameRecord;
            var mappedThird = decimal.One;
            var mappedFourth = PlusFifteenIdLowerSomeStringNameRecord;
            var mappedFifth = long.MaxValue;

            var actual = source.Map(
                _ => mappedFirst,
                _ => mappedSecond,
                _ => mappedThird,
                _ => mappedFourth,
                _ => mappedFifth,
                _ => mappedLast);

            var actualValue = actual.Resolve();
            var expectedValue = (mappedFirst, mappedSecond, mappedThird, mappedFourth, mappedFifth, mappedLast);

            Assert.Equal(expectedValue, actualValue);
        }
    }
}