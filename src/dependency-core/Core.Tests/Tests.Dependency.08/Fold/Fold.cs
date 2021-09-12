using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Fact]
        public void Fold_FoldFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => SomeTextStructType,
                _ => Zero,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => new object(),
                _ => ZeroIdRefType,
                _ => ThreeWhiteSpacesString,
                _ => DateTimeKind.Utc,
                _ => decimal.One);

            var fold = (Func<StructType, int, RecordType, object?, RefType?, string, DateTimeKind, decimal, long?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Fold(fold));
            
            Assert.Equal("fold", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void Fold_FoldFuncIsNotNull_ExpectResolvedValueIsEqualToFolded(
            RecordType? foldedValue)
        {
            var source = Dependency.From(
                _ => new object(),
                _ => MinusFifteenIdRefType,
                _ => new[] { true, false, true },
                _ => PlusFifteen,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => byte.MaxValue,
                _ => UpperSomeString,
                _ => LowerSomeTextStructType);

            var actual = source.Fold((_, _, _, _, _, _, _, _) => foldedValue);
            var actualValue = actual.Resolve();
            
            Assert.Equal(foldedValue, actualValue);
        }
    }
}