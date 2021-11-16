using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class TwoDependencyTest
{
    [Fact]
    public void FoldWithProvider_FoldFuncIsNull_ExpectArgumentNullException()
    {
        var source = Dependency.From(_ => MinusFifteen, _ => SomeTextStructType);
        var fold = (Func<IServiceProvider, int, StructType, RefType?>)null!;

        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = source.Fold(fold));

        Assert.Equal("fold", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void FoldWithProvider_FoldFuncIsNotNull_ExpectResolvedValueIsEqualToFolded(
        RecordType foldedValue)
    {
        var source = Dependency.From(_ => ZeroIdNullNameRecord, _ => PlusFifteenIdRefType);
        var actual = source.Fold((_, _, _) => foldedValue);

        var actualValue = actual.Resolve();
        Assert.Equal(foldedValue, actualValue);
    }
}