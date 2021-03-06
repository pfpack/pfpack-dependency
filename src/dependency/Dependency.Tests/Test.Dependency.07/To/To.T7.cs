#nullable enable

using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void ToSeventh_ExpectResolvedValueIsEqualToSeventhSource(
            RecordType? seventhSource)
        {
            var source = Dependency.Create(
                _ => SomeTextStructType,
                _ => new { Text = LowerSomeString },
                _ => byte.MaxValue,
                _ => decimal.MinusOne,
                _ => TabString,
                _ => MinusFifteenIdRefType,
                _ => seventhSource);

            var actual = source.ToSeventh();

            var actualValue = actual.Resolve();
            Assert.Equal(seventhSource, actualValue);
        }
    }
}