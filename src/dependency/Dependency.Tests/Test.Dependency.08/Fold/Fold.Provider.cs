#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Fact]
        public void FoldWithProvider_FoldFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => MinusFifteen,
                _ => new { Value = decimal.MinValue },
                _ => false,
                _ => LowerSomeString,
                _ => long.MinValue,
                _ => SomeTextStructType,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => DateTimeKind.Unspecified);

            var fold = (Func<IServiceProvider, int, object, bool, string?, long, StructType, RecordType, DateTimeKind, RefType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Fold(fold));
            
            Assert.Equal("fold", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void FoldWithProvider_FoldFuncIsNotNull_ExpectResolvedValueIsEqualToFolded(
            StructType foldedValue)
        {
            var source = Dependency.Create(
                _ => int.MinValue,
                _ => new object(),
                _ => WhiteSpaceString,
                _ => Array.Empty<bool>(),
                _ => SomeTextStructType,
                _ => ZeroIdNullNameRecord,
                _ => PlusFifteenIdRefType,
                _ => long.MaxValue);

            var actual = source.Fold((_, _, _, _, _, _, _, _, _) => foldedValue);
            var actualValue = actual.Resolve();
            
            Assert.Equal(foldedValue, actualValue);
        }
    }
}