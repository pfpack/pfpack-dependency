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
        public void Map_MapFirstFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => PlusFifteen,
                _ => SomeTextStructType,
                _ => ZeroIdRefType,
                _ => new object(),
                _ => PlusFifteenIdSomeStringNameRecord);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (Func<int, DateTime?>)null!,
                    _ => WhiteSpaceString,
                    _ => long.MaxValue,
                    _ => MinusFifteen,
                    _ => LowerSomeString));
            
            Assert.Equal("mapFirst", ex.ParamName);
        }

        [Fact]
        public void Map_MapSecondFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdRefType,
                _ => LowerSomeString,
                _ => PlusFifteen,
                _ => SomeTextStructType,
                _ => ZeroIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => SomeTextStructType,
                    (Func<string, long>)null!,
                    _ => decimal.One,
                    _ => new object(),
                    _ => WhiteSpaceString));
            
            Assert.Equal("mapSecond", ex.ParamName);
        }

        [Fact]
        public void Map_MapThirdFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => ZeroIdRefType,
                _ => PlusFifteen,
                _ => LowerSomeString,
                _ => LowerSomeTextStructType,
                _ => decimal.One);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => EmptyString,
                    _ => MinusFifteenIdNullNameRecord,
                    (Func<string?, object>)null!,
                    _ => PlusFifteenIdRefType,
                    _ => new { Value = long.MaxValue }));
            
            Assert.Equal("mapThird", ex.ParamName);
        }

        [Fact]
        public void Map_MapFourthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => MinusFifteen,
                _ => SomeTextStructType,
                _ => ZeroIdRefType,
                _ => UpperSomeString,
                _ => MinusFifteenIdSomeStringNameRecord);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => SomeString,
                    _ => WhiteSpaceString,
                    _ => long.MaxValue,
                    (Func<string, long?>)null!,
                    _ => new object()));
            
            Assert.Equal("mapFourth", ex.ParamName);
        }

        [Fact]
        public void Map_MapFifthFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => ZeroIdRefType,
                _ => LowerSomeTextStructType,
                _ => PlusFifteenIdSomeStringNameRecord,
                _ => WhiteSpaceString,
                _ => MinusFifteenIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => SomeTextStructType,
                    _ => PlusFifteen,
                    _ => decimal.One,
                    _ => int.MaxValue,
                    (Func<RefType, StructType>)null!));
            
            Assert.Equal("mapFifth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void Map_MapFuncIsNotNull_ExpectResolvedValuesAreSameAsMapped(
            RefType mappedLast)
        {
            var source = Dependency.Create(
                _ => PlusFifteenIdSomeStringNameRecord,
                _ => SomeString,
                _ => int.MaxValue,
                _ => MinusFifteenIdRefType,
                _ => PlusFifteen);

            var mappedFirst = default(DateTime);
            var mappedSecond = MinusFifteenIdSomeStringNameRecord;
            var mappedThird = ZeroIdRefType;
            var mappedFourth = new object();

            var actual = source.Map(
                _ => mappedFirst,
                _ => mappedSecond,
                _ => mappedThird,
                _ => mappedFourth,
                _ => mappedLast);

            var actualValue = actual.Resolve();
            var expectedValue = (mappedFirst, mappedSecond, mappedThird, mappedFourth, mappedLast);

            Assert.Equal(expectedValue, actualValue);
        }
    }
}