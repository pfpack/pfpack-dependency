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
        public void Fold_FoldFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => MinusFifteen, _ => LowerSomeString, _ => PlusFifteenIdRefType);
            var fold = null as Func<int, string?, RefType, StructType>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Fold(fold!));
            
            Assert.Equal("fold", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void Fold_FoldFuncIsNotNull_ExpectResolvedValueIsSameAsMapped(
            RecordType? mappedValue)
        {
            var source = Dependency.Create(_ => UpperSomeString, _ => MinusFifteenIdRefType, _ => LowerSomeTextStructType);
            var actual = source.Fold((_, _, _) => mappedValue);

            var actualValue = actual.Resolve();
            Assert.Equal(mappedValue, actualValue);
        }
    }
}