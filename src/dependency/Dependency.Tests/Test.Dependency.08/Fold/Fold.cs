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
        public void Fold_FoldFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
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
    }
}