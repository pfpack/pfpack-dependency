#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void ToFifth_ExpectResolvedValueIsEqualToFifthSource(
            RecordType? fifthSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdRefType,
                _ => new object(),
                _ => SomeTextStructType,
                _ => MinusFifteen,
                _ => fifthSource,
                _ => ZeroIdRefType);

            var actual = source.ToFifth();

            var actualValue = actual.Resolve();
            Assert.Equal(fifthSource, actualValue);
        }
    }
}