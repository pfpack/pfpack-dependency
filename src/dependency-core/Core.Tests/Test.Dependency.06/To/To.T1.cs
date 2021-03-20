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
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void ToFirst_ExpectResolvedValueIsEqualToFirstSource(
            StructType firstSource)
        {
            var source = Dependency.Create(
                _ => firstSource,
                _ => MinusFifteenIdNullNameRecord,
                _ => PlusFifteen,
                _ => DateTimeKind.Unspecified,
                _ => MinusFifteenIdRefType,
                _ => UpperSomeString);

            var actual = source.ToFirst();
            var actualValue = actual.Resolve();

            Assert.Equal(firstSource, actualValue);
        }
    }
}