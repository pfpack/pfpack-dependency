#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Fact]
        public void FoldWithProvider_FoldFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => new object(),
                _ => MinusFifteenIdRefType,
                _ => SomeTextStructType,
                _ => DateTimeKind.Unspecified,
                _ => PlusFifteenIdSomeStringNameRecord,
                _ => WhiteSpaceString,
                _ => byte.MaxValue);

            var fold = (Func<IServiceProvider, object?, RefType, StructType, DateTimeKind, RecordType, string?, byte, decimal>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Fold(fold));
            
            Assert.Equal("fold", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void FoldWithProvider_FoldFuncIsNotNull_ExpectResolvedValueIsEqualToMapped(
            StructType mappedValue)
        {
            var source = Dependency.Create(
                _ => DateTimeKind.Local,
                _ => LowerSomeTextStructType,
                _ => new { Id = int.MaxValue },
                _ => ZeroIdNullNameRecord,
                _ => decimal.One,
                _ => PlusFifteenIdRefType,
                _ => long.MinValue);

            var actual = source.Fold((_, _, _, _, _, _, _, _) => mappedValue);
            var actualValue = actual.Resolve();
            
            Assert.Equal(mappedValue, actualValue);
        }
    }
}