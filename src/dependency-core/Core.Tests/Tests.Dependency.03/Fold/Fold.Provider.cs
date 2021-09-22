using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Fact]
        public void FoldWithProvider_FoldFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => ZeroIdRefType, _ => new object(), _ => long.MaxValue);
            var fold = (Func<IServiceProvider, RefType, object, long, RecordType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Fold(fold));
            
            Assert.Equal("fold", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void FoldWithProvider_FoldFuncIsNotNull_ExpectResolvedValueIsEqualToFolded(
            StructType foldedValue)
        {
            var source = Dependency.From(_ => PlusFifteen, _ => ZeroIdNullNameRecord, _ => PlusFifteenIdRefType);
            var actual = source.Fold((_, _, _, _) => foldedValue);

            var actualValue = actual.Resolve();
            Assert.Equal(foldedValue, actualValue);
        }
    }
}