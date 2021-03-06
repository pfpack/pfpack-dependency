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
        public void Fold_FoldFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => PlusFifteen,
                _ => UpperSomeString,
                _ => ZeroIdRefType,
                _ => decimal.One,
                _ => DateTimeKind.Utc,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => new object());

            var fold = (Func<int, string, RefType?, decimal, DateTimeKind, RecordType?, object, DateTime>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Fold(fold));
            
            Assert.Equal("fold", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(false)]
        [InlineData(true)]
        public void Fold_FoldFuncIsNotNull_ExpectResolvedValueIsEqualToMapped(
            bool? mappedValue)
        {
            var source = Dependency.Create(
                _ => SomeTextStructType,
                _ => byte.MaxValue,
                _ => ZeroIdNullNameRecord,
                _ => UpperSomeString,
                _ => LowerSomeTextStructType,
                _ => (PlusFifteen, WhiteSpaceString),
                _ => new { Id = PlusFifteen });

            var actual = source.Fold((_, _, _, _, _, _, _) => mappedValue);
            var actualValue = actual.Resolve();
            
            Assert.Equal(mappedValue, actualValue);
        }
    }
}