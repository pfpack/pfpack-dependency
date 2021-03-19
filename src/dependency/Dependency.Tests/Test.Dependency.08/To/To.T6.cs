#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void ToSixth_ExpectResolvedValueIsEqualToSixthSource(
            RefType? sixthSource)
        {
            var source = Dependency.Create(
                _ => Array.Empty<decimal>(),
                _ => UpperSomeString,
                _ => MinusOne,
                _ => long.MaxValue,
                _ => ZeroIdNullNameRecord,
                _ => sixthSource,
                _ => SomeTextStructType,
                _ => new object());

            var actual = source.ToSixth();
            var actualValue = actual.Resolve();

            Assert.Equal(sixthSource, actualValue);
        }
    }
}