#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void FoldWithProvider_FoldFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => MinusFifteen, _ => SomeTextStructType);
            var fold = (Func<IServiceProvider, int, StructType, RefType?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Fold(fold));
            
            Assert.Equal("fold", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void FoldWithProvider_FoldFuncIsNotNull_ExpectResolvedValueIsEqualToMapped(
            RecordType mappedValue)
        {
            var source = Dependency.Create(_ => ZeroIdNullNameRecord, _ => PlusFifteenIdRefType);
            var actual = source.Fold((_, _, _) => mappedValue);

            var actualValue = actual.Resolve();
            Assert.Equal(mappedValue, actualValue);
        }
    }
}