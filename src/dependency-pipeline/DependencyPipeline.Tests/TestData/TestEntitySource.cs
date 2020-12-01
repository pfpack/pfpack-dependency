#nullable enable

using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    internal static class TestEntitySource
    {
        public static IEnumerable<object?[]> RefTypeTestSource
            =>
            new[]
            {
                PlusFifteenIdRefType,
                MinusFifteenIdRefType,
                null
            }
            .Select(
                value => new object?[] { value });

        public static IEnumerable<object[]> StructTypeTestSource
            =>
            new[]
            {
                SomeTextStructType,
                NullTextStructType,
                default
            }
            .Select(
                value => new object[] { value });
    }
}
