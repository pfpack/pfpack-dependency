using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void Map_MapFirstFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => int.MaxValue, _ => MinusFifteenIdRefType);
            var mapFirst = (Func<int, StructType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(mapFirst, _ => PlusFifteenIdLowerSomeStringNameRecord));
            
            Assert.Equal("mapFirst", ex.ParamName);
        }

        [Fact]
        public void Map_MapSecondFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => SomeTextStructType, _ => UpperSomeString);
            var mapSecond = (Func<string, DateTime?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(_ => MinusFifteen, mapSecond));
            
            Assert.Equal("mapSecond", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void Map_MapFuncIsNotNull_ExpectResolvedValuesAreEqualToMapped(
            RecordType? mappedLast)
        {
            var source = Dependency.From(_ => SomeTextStructType, _ => MinusFifteen);
            var mappedFirst = PlusFifteenIdRefType;

            var actual = source.Map(_ => mappedFirst, _ => mappedLast);
            var actualValue = actual.Resolve();

            var expectedValue = (mappedFirst, mappedLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}