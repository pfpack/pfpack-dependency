using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Fact]
        public void Map_MapFirstFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => LowerSomeString, _ => ZeroIdRefType, _ => MinusFifteenIdSomeStringNameRecord, _ => int.MinValue);

            var mapFirst = (Func<string?, long>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    mapFirst, _ => SomeTextStructType, _ => decimal.Zero, _ => new object()));
            
            Assert.Equal("mapFirst", ex.ParamName);
        }

        [Fact]
        public void Map_MapSecondFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => int.MaxValue, _ => PlusFifteenIdRefType, _ => decimal.One, _ => LowerSomeTextStructType);

            var mapSecond = (Func<RefType, DateTimeOffset?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => MinusFifteenIdSomeStringNameRecord, mapSecond, _ => ZeroIdRefType, _ => PlusFifteen));
            
            Assert.Equal("mapSecond", ex.ParamName);
        }

        [Fact]
        public void Map_MapThirdFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => LowerSomeString, _ => Zero, _ => default(StructType), _ => new object());

            var mapThird = (Func<StructType, RecordType?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => WhiteSpaceString, _ => decimal.MinValue, mapThird, _ => LowerSomeTextStructType));
            
            Assert.Equal("mapThird", ex.ParamName);
        }

        [Fact]
        public void Map_MapFourthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdSomeStringNameRecord, _ => LowerSomeString, _ => int.MaxValue, _ => decimal.MinusOne);

            var mapFourth = (Func<decimal, RecordType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => new { Text = SomeString }, _ => SomeTextStructType, _ => PlusFifteen, mapFourth));
            
            Assert.Equal("mapFourth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void Map_MapFuncIsNotNull_ExpectResolvedValuesAreEqualToMapped(
            RecordType? mappedLast)
        {
            var source = Dependency.Create(
                _ => LowerSomeTextStructType, _ => MinusFifteenIdRefType, _ => LowerSomeString, _ => new object());

            var mappedFirst = long.MaxValue;
            var mappedSecond = EmptyString;
            var mappedThird = PlusFifteenIdLowerSomeStringNameRecord;

            var actual = source.Map(_ => mappedFirst, _ => mappedSecond, _ => mappedThird, _ => mappedLast);
            var actualValue = actual.Resolve();

            var expectedValue = (mappedFirst, mappedSecond, mappedThird, mappedLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}