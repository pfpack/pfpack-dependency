using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void MapWithProvider_MapFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => PlusFifteenIdRefType);
            var map = (Func<IServiceProvider, RefType, RecordType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(map));
            
            Assert.Equal("map", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void MapWithProvider_MapFuncIsNotNull_ExpectResolvedValueIsEqualToMapped(
            StructType mappedValue)
        {
            var source = Dependency.From(_ => MinusFifteenIdSomeStringNameRecord);
            var actual = source.Map((sp, _) => mappedValue);

            var actualValue = actual.Resolve();
            Assert.Equal(mappedValue, actualValue);
        }
    }
}