using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class TwoDependencyTest
{
    [Fact]
    public void Fold_FoldFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => PlusFifteenIdRefType, _ => SomeString);
        var fold = (Func<RefType, string, StructType>)null!;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Fold(fold));

        Assert.Equal("fold", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void Fold_FoldFuncIsNotNull_ExpectResolvedValueIsEqualToFolded(
        RefType? foldedValue)
    {
        var source = Dependency.From(_ => MinusFifteen, _ => LowerSomeTextStructType);
        var actual = source.Fold((_, _) => foldedValue);

        var actualValue = actual.Resolve();
        Assert.Equal(foldedValue, actualValue);
    }
}
