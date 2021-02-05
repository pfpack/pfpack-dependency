#nullable enable

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
            var source = Dependency.Create(_ => ZeroIdRefType, _ => new object(), _ => long.MaxValue);
            var fold = (Func<IServiceProvider, RefType, object, long, RecordType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Fold(fold));
            
            Assert.Equal("fold", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void FoldWithProvider_FoldFuncIsNotNull_ExpectResolvedValueIsSameAsMapped(
            StructType mappedValue)
        {
            var source = Dependency.Create(_ => PlusFifteen, _ => ZeroIdNullNameRecord, _ => PlusFifteenIdRefType);
            var actual = source.Fold((_, _, _, _) => mappedValue);

            var actualValue = actual.Resolve();
            Assert.Equal(mappedValue, actualValue);
        }
    }
}