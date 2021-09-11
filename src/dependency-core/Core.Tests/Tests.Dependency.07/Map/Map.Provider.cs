using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Fact]
        public void MapWithProvider_MapFirstFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => MinusFifteen,
                _ => PlusFifteenIdRefType,
                _ => LowerSomeString,
                _ => SomeTextStructType,
                _ => long.MinValue,
                _ => DateTimeKind.Unspecified,
                _ => true);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (Func<IServiceProvider, int, DateTimeOffset>)null!,
                    (_, _) => new object(),
                    (_, _) => ZeroIdNullNameRecord,
                    (_, _) => new { Id = MinusFifteen },
                    (_, _) => false,
                    (_, _) => ZeroIdRefType,
                    (_, _) => (Zero, LowerSomeTextStructType)));
            
            Assert.Equal("mapFirst", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapSecondFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => new object(),
                _ => MinusFifteenIdRefType,
                _ => PlusFifteenIdSomeStringNameRecord,
                _ => int.MaxValue,
                _ => SomeTextStructType,
                _ => decimal.One,
                _ => LowerSomeString);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => true,
                    (Func<IServiceProvider, RefType?, object>)null!,
                    (_, _) => LowerSomeTextStructType,
                    (_, _) => TabString,
                    (_, _) => MinusFifteenIdNullNameRecord,
                    (_, _) => ZeroIdRefType,
                    (_, _) => DateTimeKind.Local));
            
            Assert.Equal("mapSecond", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapThirdFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => false,
                _ => (int.MaxValue, WhiteSpaceString),
                _ => SomeTextStructType,
                _ => new object(),
                _ => MinusFifteenIdRefType,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => DateTimeKind.Utc);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => MinusFifteen,
                    (_, _) => ZeroIdNullNameRecord,
                    (Func<IServiceProvider, StructType, RecordType>)null!,
                    (_, _) => PlusFifteenIdRefType,
                    (_, _) => byte.MaxValue,
                    (_, _) => UpperSomeString,
                    (_, _) => long.MaxValue));
            
            Assert.Equal("mapThird", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapFourthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => MinusFifteenIdNullNameRecord,
                _ => PlusFifteen,
                _ => decimal.MinusOne,
                _ => PlusFifteenIdRefType,
                _ => new { Id = long.MaxValue },
                _ => SomeString,
                _ => true);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => Zero,
                    (_, _) => ZeroIdRefType,
                    (_, _) => DateTimeKind.Unspecified,
                    (Func<IServiceProvider, RefType?, StructType?>)null!,
                    (_, _) => MinusFifteenIdSomeStringNameRecord,
                    (_, _) => long.MinValue,
                    (_, _) => new object()));
            
            Assert.Equal("mapFourth", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapFifthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => TabString,
                _ => PlusFifteen,
                _ => DateTimeKind.Utc,
                _ => SomeTextStructType,
                _ => byte.MaxValue,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => ZeroIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => MinusFifteenIdNullNameRecord,
                    (_, _) => LowerSomeTextStructType,
                    (_, _) => double.MaxValue,
                    (_, _) => PlusFifteenIdRefType,
                    (Func<IServiceProvider, byte, string?>)null!,
                    (_, _) => new object(),
                    (_, _) => (byte.MaxValue, SomeString)));
            
            Assert.Equal("mapFifth", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapSixthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => ZeroIdNullNameRecord,
                _ => (SomeString, MinusFifteen),
                _ => long.MaxValue,
                _ => LowerSomeTextStructType,
                _ => ThreeWhiteSpacesString,
                _ => decimal.MinValue,
                _ => ZeroIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => SomeTextStructType,
                    (_, _) => PlusFifteenIdRefType,
                    (_, _) => DateTimeKind.Local,
                    (_, _) => false,
                    (_, _) => PlusFifteenIdSomeStringNameRecord,
                    (Func<IServiceProvider, decimal, object>)null!,
                    (_, _) => decimal.One));
            
            Assert.Equal("mapSixth", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapSeventhFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => new object(),
                _ => true,
                _ => UpperSomeString,
                _ => PlusFifteenIdRefType,
                _ => SomeTextStructType,
                _ => byte.MaxValue,
                _ => MinusFifteenIdSomeStringNameRecord);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => DateTimeKind.Utc,
                    (_, _) => ZeroIdRefType,
                    (_, _) => decimal.MaxValue,
                    (_, _) => LowerSomeTextStructType,
                    (_, _) => PlusFifteenIdLowerSomeStringNameRecord,
                    (_, _) => new { Id = PlusFifteen },
                    (Func<IServiceProvider, RecordType, DateTime>)null!));
            
            Assert.Equal("mapSeventh", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void MapWithProvider_MapFuncIsNotNull_ExpectResolvedValuesAreEqualToMapped(
            RecordType? mappedLast)
        {
            var source = Dependency.From(
                _ => new object(),
                _ => MinusFifteen,
                _ => SomeString,
                _ => MinusFifteenIdRefType,
                _ => ZeroIdNullNameRecord,
                _ => decimal.MinusOne,
                _ => byte.MaxValue);

            var mappedFirst = DateTimeKind.Local;
            var mappedSecond = LowerSomeTextStructType;
            var mappedThird = int.MaxValue;
            var mappedFourth = new { Id = long.MaxValue, Name = SomeString };
            var mappedFifth = UpperSomeString;
            var mappedSixth = (MinusFifteen, true);

            var actual = source.Map(
                (_, _) => mappedFirst,
                (_, _) => mappedSecond,
                (_, _) => mappedThird,
                (_, _) => mappedFourth,
                (_, _) => mappedFifth,
                (_, _) => mappedSixth,
                (_, _) => mappedLast);

            var actualValue = actual.Resolve();
            var expectedValue = (mappedFirst, mappedSecond, mappedThird, mappedFourth, mappedFifth, mappedSixth, mappedLast);

            Assert.Equal(expectedValue, actualValue);
        }
    }
}