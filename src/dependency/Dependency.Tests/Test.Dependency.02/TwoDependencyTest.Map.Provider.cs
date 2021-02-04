#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void MapWithProvider_MapFirstFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => PlusFifteenIdSomeStringNameRecord, _ => decimal.MinusOne);
            var mapFirst = null as Func<IServiceProvider, RecordType, long?>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(mapFirst!, (_, _) => MinusFifteen));
            
            Assert.Equal("mapFirst", ex.ParamName);
        }

        [Fact]
        public void MapWithProvider_MapSecondFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => MinusFifteenIdSomeStringNameRecord, _ => SomeTextStructType);
            var mapSecond = null as Func<IServiceProvider, StructType, RefType>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map((_, _) => MinusFifteen, mapSecond!));
            
            Assert.Equal("mapSecond", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void MapWithProvider_MapFuncIsNotNull_ExpectResolvedValuesAreSameAsMapped(
            StructType mappedLast)
        {
            var source = Dependency.Create(_ => PlusFifteenIdRefType, _ => null as RecordType);
            var mappedFirst = MinusFifteenIdNullNameRecord;

            var actual = source.Map((_, _) => mappedFirst, (_, _) => mappedLast);
            var actualValue = actual.Resolve();

            var expectedValue = (mappedFirst, mappedLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}