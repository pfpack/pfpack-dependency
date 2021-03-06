#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Fact]
        public void MapWithProvider_MapFirstFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => SomeString, _ => LowerSomeTextStructType, _ => MinusFifteenIdNullNameRecord);

            var mapFirst = (Func<IServiceProvider, string, DateTimeOffset>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    mapFirst, (_, _) => MinusFifteen, (_, _) => decimal.MinusOne));
            
            Assert.Equal("mapFirst", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapSecondFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => ZeroIdRefType, _ => PlusFifteen, _ => SomeTextStructType);

            var mapSecond = (Func<IServiceProvider, int, RefType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => MinusFifteenIdSomeStringNameRecord, mapSecond, (_, _) => decimal.One));
            
            Assert.Equal("mapSecond", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapThirdFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => UpperSomeString, _ => long.MinValue, _ => MinusFifteenIdSomeStringNameRecord);

            var mapThird = (Func<IServiceProvider, RecordType, StructType?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    (_, _) => MinusFifteen, (_, _) => PlusFifteenIdLowerSomeStringNameRecord, mapThird));
            
            Assert.Equal("mapThird", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void MapWithProvider_MapFuncIsNotNull_ExpectResolvedValuesAreEqualToMapped(
            StructType mappedLast)
        {
            var source = Dependency.Create(_ => new object(), _ => SomeTextStructType, _ => PlusFifteen);

            var mappedFirst = MinusFifteenIdNullNameRecord;
            var mappedSecond = MinusFifteenIdRefType;

            var actual = source.Map((_, _) => mappedFirst, (_, _) => mappedSecond, (_, _) => mappedLast);
            var actualValue = actual.Resolve();

            var expectedValue = (mappedFirst, mappedSecond, mappedLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}