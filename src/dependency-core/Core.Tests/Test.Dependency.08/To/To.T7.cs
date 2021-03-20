#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData(false)]
        [InlineData(true)]
        public void ToSeventh_ExpectResolvedValueIsEqualToSeventhSource(
            bool? seventhSource)
        {
            var source = Dependency.Create(
                _ => ZeroIdRefType,
                _ => byte.MinValue,
                _ => WhiteSpaceString,
                _ => new { Id = MinusOne, Name = SomeString, Amount = decimal.One },
                _ => SomeTextStructType,
                _ => new Tuple<byte, long, string?>(byte.MaxValue, long.MaxValue, null),
                _ => seventhSource,
                _ => MinusFifteenIdSomeStringNameRecord);

            var actual = source.ToSeventh();
            var actualValue = actual.Resolve();

            Assert.Equal(seventhSource, actualValue);
        }
    }
}