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
        public void FoldWithProvider_FoldFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => SomeTextStructType, _ => LowerSomeString, _ => int.MaxValue, _ => PlusFifteenIdRefType);

            var fold = (Func<IServiceProvider, StructType, string, int, RefType?, object>)null!;

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
                _ => SomeTextStructType, _ => long.MaxValue, _ => LowerSomeString, _ => MinusFifteenIdRefType);

            var actual = source.Fold((_, _, _, _, _) => mappedValue);
            var actualValue = actual.Resolve();

            Assert.Equal(mappedValue, actualValue);
        }
    }
}