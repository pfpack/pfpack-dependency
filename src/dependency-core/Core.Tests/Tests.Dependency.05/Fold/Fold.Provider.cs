using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Fact]
        public void FoldWithProvider_FoldFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdRefType,
                _ => LowerSomeString,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => ZeroIdRefType,
                _ => new object());

            var fold = (Func<IServiceProvider, RefType?, string, RecordType, RefType?, object?, decimal>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Fold(fold!));
            
            Assert.Equal("fold", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void FoldWithProvider_FoldFuncIsNotNull_ExpectResolvedValueIsEqualToFolded(
            RefType? foldedValue)
        {
            var source = Dependency.Create(
                _ => LowerSomeTextStructType,
                _ => UpperSomeString,
                _ => PlusFifteenIdSomeStringNameRecord,
                _ => decimal.MaxValue,
                _ => new object());

            var actual = source.Fold((_, _, _, _, _, _) => foldedValue);
            var actualValue = actual.Resolve();
            
            Assert.Equal(foldedValue, actualValue);
        }
    }
}