using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void Map_MapFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => SomeTextStructType);
            var map = (Func<StructType, RefType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(map));
            
            Assert.Equal("map", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void Map_MapFuncIsNotNull_ExpectResolvedValueIsEqualToMapped(
            RecordType? mappedValue)
        {
            var source = Dependency.From(_ => PlusFifteenIdRefType);
            var actual = source.Map(_ => mappedValue);

            var actualValue = actual.Resolve();
            Assert.Equal(mappedValue, actualValue);
        }
    }
}