using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Fact]
        public void FoldWithProvider_FoldFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => MinusFifteenIdRefType,
                _ => SomeString,
                _ => long.MaxValue,
                _ => ZeroIdRefType,
                _ => LowerSomeTextStructType,
                _ => MinusFifteenIdSomeStringNameRecord);

            var fold = (Func<IServiceProvider, RefType, string, long, RefType?, StructType, RecordType?, int>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Fold(fold));
            
            Assert.Equal("fold", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void FoldWithProvider_FoldFuncIsNotNull_ExpectResolvedValueIsEqualToFolded(
            RefType? foldedValue)
        {
            var source = Dependency.From(
                _ => SomeTextStructType,
                _ => MinusFifteenIdNullNameRecord,
                _ => ZeroIdRefType,
                _ => decimal.MaxValue,
                _ => PlusFifteenIdRefType,
                _ => LowerSomeTextStructType);

            var actual = source.Fold((_, _, _, _, _, _, _) => foldedValue);
            var actualValue = actual.Resolve();
            
            Assert.Equal(foldedValue, actualValue);
        }
    }
}