#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Fact]
        public void MapProvider_MapFirstFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => SomeTextStructType,
                _ => MinusFifteenIdRefType,
                _ => SomeString,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => new object());

            var mapFirst = null as Func<IServiceProvider, StructType, RefType>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    mapFirst!,
                    (_, _) => MinusFifteen,
                    (_, _) => decimal.MaxValue,
                    (_, _) => decimal.MinusOne,
                    (_, _) => UpperSomeString));
            
            Assert.Equal("mapFirst", ex.ParamName);
        }

        [Fact]
        public void MapProvider_MapSecondFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => LowerSomeTextStructType,
                _ => ZeroIdRefType,
                _ => new { Name = SomeString },
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => PlusFifteenIdRefType);

            var mapSecond = null as Func<IServiceProvider, RefType?, RecordType>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => PlusFifteenIdLowerSomeStringNameRecord,
                    mapSecond!,
                    (_, _) => long.MaxValue,
                    (_, _) => SomeTextStructType,
                    (_, _) => TabString));
            
            Assert.Equal("mapSecond", ex.ParamName);
        }

        [Fact]
        public void MapProvider_MapThirdFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => ZeroIdRefType,
                _ => LowerSomeTextStructType,
                _ => WhiteSpaceString,
                _ => PlusFifteen);

            var mapThird = null as Func<IServiceProvider, StructType, RefType>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => WhiteSpaceString,
                    (_, _) => PlusFifteen,
                    mapThird!,
                    (_, _) => Zero,
                    (_, _) => new object()));
            
            Assert.Equal("mapThird", ex.ParamName);
        }

        [Fact]
        public void MapProvider_MapFourthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => LowerSomeString,
                _ => long.MaxValue,
                _ => SomeTextStructType,
                _ => EmptyString);

            var mapFourth = null as Func<IServiceProvider, StructType, RecordType>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => SomeTextStructType,
                    (_, _) => decimal.MaxValue,
                    (_, _) => MinusFifteenIdSomeStringNameRecord,
                    mapFourth!,
                    (_, _) => int.MinValue));
            
            Assert.Equal("mapFourth", ex.ParamName);
        }

        [Fact]
        public void MapProvider_MapFifthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => PlusFifteen,
                _ => UpperSomeString,
                _ => int.MaxValue,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => PlusFifteenIdRefType);

            var mapFifth = null as Func<IServiceProvider, RefType, decimal?>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => LowerSomeString,
                    (_, _) => MinusFifteenIdRefType,
                    (_, _) => MinusFifteenIdSomeStringNameRecord,
                    (_, _) => long.MaxValue,
                    mapFifth!));
            
            Assert.Equal("mapFifth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void MapProvider_MapFuncIsNotNull_ExpectResolvedValuesAreSameAsMapped(
            RecordType mappedLast)
        {
            var source = Dependency.Create(
                _ => MinusFifteen,
                _ => EmptyString,
                _ => null as RefType,
                _ => SomeTextStructType,
                _ => PlusFifteenIdRefType);

            var mappedFirst = UpperSomeString;
            var mappedSecond = decimal.One;
            var mappedThird = ZeroIdNullNameRecord;
            var mappedFourth = default(int?);

            var actual = source.Map(
                (_, _) => mappedFirst,
                (_, _) => mappedSecond,
                (_, _) => mappedThird,
                (_, _) => mappedFourth,
                (_, _) => mappedLast);

            var actualValue = actual.Resolve();
            var expectedValue = (mappedFirst, mappedSecond, mappedThird, mappedFourth, mappedLast);

            Assert.Equal(expectedValue, actualValue);
        }
    }
}