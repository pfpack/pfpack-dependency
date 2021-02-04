#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Fact]
        public void MapWithProvider_MapFirstFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => SomeTextStructType, _ => int.MaxValue, _ => decimal.MinusOne, _ => PlusFifteenIdRefType);

            var mapFirst = null as Func<IServiceProvider, StructType, DateTimeOffset?>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    mapFirst!, (_, _) => LowerSomeString, (_, _) => new object(), (_, _) => Zero));
            
            Assert.Equal("mapFirst", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapSecondFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => int.MinValue, _ => MinusFifteen, _ => PlusFifteenIdRefType, _ => SomeString);

            var mapSecond = null as Func<IServiceProvider, int, long>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => PlusFifteenIdLowerSomeStringNameRecord, mapSecond!, (_, _) => SomeString, (_, _) => MinusFifteenIdRefType));
            
            Assert.Equal("mapSecond", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapThirdFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => SomeTextStructType, _ => MinusFifteenIdRefType, _ => new object(), _ => int.MaxValue);

            var mapThird = null as Func<IServiceProvider, object?, RefType?>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => int.MinValue, (_, _) => decimal.Zero, mapThird!, (_, _) => UpperSomeString));
            
            Assert.Equal("mapThird", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapFourthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => LowerSomeString, _ => PlusFifteenIdRefType, _ => int.MinValue, _ => MinusFifteenIdSomeStringNameRecord);

            var mapFourth = null as Func<IServiceProvider, RecordType, RefType>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => MinusFifteenIdRefType, (_, _) => LowerSomeString, (_, _) => UpperSomeString, mapFourth!));
            
            Assert.Equal("mapFourth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void MapWithProvider_MapFuncIsNotNull_ExpectResolvedValuesAreSameAsMapped(
            StructType mappedLast)
        {
            var source = Dependency.Create(
                _ => MinusFifteen, _ => UpperSomeString, _ => LowerSomeTextStructType, _ => MinusFifteenIdRefType);

            var mappedFirst = MinusFifteenIdNullNameRecord;
            var mappedSecond = ZeroIdRefType;
            var mappedThird = LowerSomeString;

            var actual = source.Map(
                (_, _) => mappedFirst, (_, _) => mappedSecond, (_, _) => mappedThird, (_, _) => mappedLast);

            var actualValue = actual.Resolve();
            var expectedValue = (mappedFirst, mappedSecond, mappedThird, mappedLast);
            
            Assert.Equal(expectedValue, actualValue);
        }
    }
}