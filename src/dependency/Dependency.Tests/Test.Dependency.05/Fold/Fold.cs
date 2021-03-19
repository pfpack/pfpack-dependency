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
        public void Fold_FoldFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => SomeTextStructType,
                _ => MinusFifteen,
                _ => decimal.MaxValue,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => MinusFifteenIdRefType);

            var fold = (Func<StructType, int, decimal, RecordType, RefType?, string>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Fold(fold));
            
            Assert.Equal("fold", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void Fold_FoldFuncIsNotNull_ExpectResolvedValueIsEqualToFolded(
            StructType foldedValue)
        {
            var source = Dependency.Create(
                _ => ZeroIdNullNameRecord,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => MinusFifteenIdRefType,
                _ => LowerSomeString,
                _ => decimal.MinusOne);

            var actual = source.Fold((_, _, _, _, _) => foldedValue);
            var actualValue = actual.Resolve();
            
            Assert.Equal(foldedValue, actualValue);
        }
    }
}