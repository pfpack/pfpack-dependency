using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class ThreeDependencyTest
{
    [Fact]
    public void Fold_FoldFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => MinusFifteen, _ => LowerSomeString, _ => PlusFifteenIdRefType);
        var fold = (Func<int, string?, RefType, StructType>)null!;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Fold(fold));

        Assert.Equal("fold", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void Fold_FoldFuncIsNotNull_ExpectResolvedValueIsEqualToFolded(
        RecordType? foldedValue)
    {
        var source = Dependency.From(_ => UpperSomeString, _ => MinusFifteenIdRefType, _ => LowerSomeTextStructType);
        var actual = source.Fold((_, _, _) => foldedValue);

        var actualValue = actual.Resolve();
        Assert.Equal(foldedValue, actualValue);
    }
}