using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class EightDependencyTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(false)]
    [InlineData(true)]
    public void GetSeventh_ExpectResolvedValueIsEqualToSeventhSource(
        bool? seventhSource)
    {
        var source = Dependency.From(
            _ => ZeroIdRefType,
            _ => byte.MinValue,
            _ => WhiteSpaceString,
            _ => new { Id = MinusOne, Name = SomeString, Amount = decimal.One },
            _ => SomeTextStructType,
            _ => new Tuple<byte, long, string?>(byte.MaxValue, long.MaxValue, null),
            _ => seventhSource,
            _ => MinusFifteenIdSomeStringNameRecord);

        var actual = source.GetSeventh();
        var actualValue = actual.Resolve();

        Assert.Equal(seventhSource, actualValue);
    }
}
