#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Fact]
        public void Fold_FoldFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => ZeroIdRefType, _ => SomeTextStructType, _ => MinusFifteenIdSomeStringNameRecord, _ => decimal.MinusOne);

            var fold = (Func<RefType?, StructType, RecordType, decimal, int?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Fold(fold));
            
            Assert.Equal("fold", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void Fold_FoldFuncIsNotNull_ExpectResolvedValueIsEqualToFolded(
            RecordType foldedValue)
        {
            var source = Dependency.Create(
                _ => PlusFifteenIdRefType, _ => EmptyString, _ => UpperSomeString, _ => SomeTextStructType);

            var actual = source.Fold((_, _, _, _) => foldedValue);
            var actualValue = actual.Resolve();
            
            Assert.Equal(foldedValue, actualValue);
        }
    }
}