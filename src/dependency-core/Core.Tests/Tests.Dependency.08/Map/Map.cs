using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Fact]
        public void Map_MapFirstFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdRefType,
                _ => PlusFifteen,
                _ => new object(),
                _ => SomeTextStructType,
                _ => DateTimeKind.Utc,
                _ => false,
                _ => PlusFifteenIdRefType,
                _ => TwoTabsString);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (Func<RefType, int>)null!,
                    _ => UpperSomeString,
                    _ => LowerSomeTextStructType,
                    _ => decimal.One,
                    _ => (MinusFifteen, WhiteSpaceString),
                    _ => ZeroIdNullNameRecord,
                    _ => new { Id = One },
                    _ => true));
            
            Assert.Equal("mapFirst", ex.ParamName);
        }

        [Fact]
        public void Map_MapSecondFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => new { Name = SomeString },
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => ZeroIdRefType,
                _ => decimal.MinusOne,
                _ => ThreeWhiteSpacesString,
                _ => byte.MaxValue,
                _ => SomeTextStructType,
                _ => DateTimeKind.Local);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => true,
                    (Func<RecordType?, DateTimeOffset?>)null!,
                    _ => PlusFifteen,
                    _ => new object(),
                    _ => ZeroIdRefType,
                    _ => LowerSomeString,
                    _ => MinusFifteenIdNullNameRecord,
                    _ => LowerSomeTextStructType));
            
            Assert.Equal("mapSecond", ex.ParamName);
        }

        [Fact]
        public void Map_MapThirdFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => LowerSomeString,
                _ => new object(),
                _ => SomeTextStructType,
                _ => (true, WhiteSpaceString),
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => DateTimeKind.Unspecified,
                _ => decimal.MinusOne,
                _ => ZeroIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => MinusOne,
                    _ => LowerSomeTextStructType,
                    (Func<StructType, string?>)null!,
                    _ => DateTimeOffset.MinValue,
                    _ => MinusFifteenIdRefType,
                    _ => decimal.MaxValue,
                    _ => PlusFifteenIdLowerSomeStringNameRecord,
                    _ => false));
            
            Assert.Equal("mapThird", ex.ParamName);
        }

        [Fact]
        public void Map_MapFourthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => (PlusFifteen, SomeString),
                _ => MinusFifteen,
                _ => new { Id = Zero },
                _ => PlusFifteenIdRefType,
                _ => decimal.MaxValue,
                _ => ZeroIdNullNameRecord,
                _ => SomeTextStructType,
                _ => byte.MaxValue);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => DateTimeKind.Local,
                    _ => LowerSomeTextStructType,
                    _ => decimal.MinusOne,
                    (Func<RefType?, DateTime>)null!,
                    _ => PlusFifteenIdSomeStringNameRecord,
                    _ => PlusFifteen,
                    _ => true,
                    _ => new object()));
            
            Assert.Equal("mapFourth", ex.ParamName);
        }

        [Fact]
        public void Map_MapFifthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => LowerSomeTextStructType,
                _ => new { Value = MinusOne },
                _ => decimal.MaxValue,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => UpperSomeString,
                _ => false,
                _ => DateTime.MaxValue,
                _ => PlusFifteenIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => MinusFifteen,
                    _ => TwoWhiteSpacesString,
                    _ => ZeroIdRefType,
                    _ => SomeTextStructType,
                    (Func<string, (int Id, DateTimeOffset Date)>)null!,
                    _ => PlusFifteenIdLowerSomeStringNameRecord,
                    _ => new { Text = SomeString },
                    _ => byte.MaxValue));
            
            Assert.Equal("mapFifth", ex.ParamName);
        }

        [Fact]
        public void Map_MapSixthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdRefType,
                _ => byte.MaxValue,
                _ => new { Id = MinusFifteen },
                _ => Zero,
                _ => LowerSomeTextStructType,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => ThreeWhiteSpacesString,
                _ => DateTimeOffset.MaxValue);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => new object(),
                    _ => false,
                    _ => UpperSomeString,
                    _ => (EmptyString, PlusFifteen),
                    _ => ZeroIdRefType,
                    (Func<RecordType, byte?>)null!,
                    _ => decimal.MaxValue,
                    _ => MinusFifteenIdNullNameRecord));
            
            Assert.Equal("mapSixth", ex.ParamName);
        }

        [Fact]
        public void Map_MapSeventhFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => SomeTextStructType,
                _ => true,
                _ => ZeroIdRefType,
                _ => PlusFifteenIdSomeStringNameRecord,
                _ => decimal.Zero,
                _ => byte.MaxValue,
                _ => DateTime.MaxValue,
                _ => new object());

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => decimal.MinValue,
                    _ => new { Text = UpperSomeString },
                    _ => int.MaxValue,
                    _ => MinusFifteenIdRefType,
                    _ => DateTimeKind.Unspecified,
                    _ => LowerSomeTextStructType,
                    (Func<DateTime, object>)null!,
                    _ => ZeroIdNullNameRecord));
            
            Assert.Equal("mapSeventh", ex.ParamName);
        }

        [Fact]
        public void Map_MapRestFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => DateTimeOffset.MinValue,
                _ => ZeroIdNullNameRecord,
                _ => new { Text = WhiteSpaceString },
                _ => MinusFifteen,
                _ => SomeTextStructType,
                _ => false,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => byte.MaxValue);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => SomeString,
                    _ => MinusOne,
                    _ => LowerSomeTextStructType,
                    _ => PlusFifteenIdRefType,
                    _ => new object(),
                    _ => MinusFifteenIdNullNameRecord,
                    _ => decimal.MaxValue,
                    (Func<byte, DateTime>)null!));
            
            Assert.Equal("mapRest", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(MinusOne)]
        [InlineData(PlusFifteen)]
        public void Map_MapFuncIsNotNull_ExpectResolvedValuesAreEqualToMapped(
            int? mappedLast)
        {
            var source = Dependency.Create(
                _ => ThreeWhiteSpacesString,
                _ => new object(),
                _ => MinusFifteenIdNullNameRecord,
                _ => decimal.MaxValue,
                _ => LowerSomeTextStructType,
                _ => ZeroIdRefType,
                _ => true,
                _ => (MinusFifteen, UpperSomeString));

            var mappedFirst = PlusFifteenIdRefType;
            var mappedSecond = false;
            var mappedThird = SomeTextStructType;
            var mappedFourth = new { Id = PlusFifteen, Name = SomeString };
            var mappedFifth = EmptyString;
            var mappedSixth = MinusFifteenIdSomeStringNameRecord;
            var mappedSeventh = DateTimeKind.Utc;

            var actual = source.Map(
                _ => mappedFirst,
                _ => mappedSecond,
                _ => mappedThird,
                _ => mappedFourth,
                _ => mappedFifth,
                _ => mappedSixth,
                _ => mappedSeventh,
                _ => mappedLast);

            var actualValue = actual.Resolve();
            var expectedValue = ((mappedFirst, mappedSecond, mappedThird, mappedFourth), (mappedFifth, mappedSixth, mappedSeventh, mappedLast));

            Assert.Equal(expectedValue, actualValue);
        }
    }
}