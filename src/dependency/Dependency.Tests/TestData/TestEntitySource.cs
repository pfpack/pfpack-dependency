#nullable enable

using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    internal static class TestEntitySource
    {
        public static IEnumerable<object?[]> RefTypes
            =>
            new[]
            {
                PlusFifteenIdRefType,
                MinusFifteenIdRefType,
                null
            }
            .ToNullableTestSourceValues();

        public static IEnumerable<object?[]> RecordTypes
            =>
            new[]
            {
                PlusFifteenIdSomeStringNameRecord,
                MinusFifteenIdNullNameRecord,
                ZeroIdNullNameRecord,
                null
            }
            .ToNullableTestSourceValues();

        public static IEnumerable<object[]> StructTypes
            =>
            new[]
            {
                SomeTextStructType,
                NullTextStructType,
                default
            }
            .ToTestSourceValues();

        private static IEnumerable<object[]> ToTestSourceValues<T>(
            this IEnumerable<T> source)
            where T : notnull
            =>
            source.Select(
                value => new object[] { value });

        private static IEnumerable<object?[]> ToNullableTestSourceValues<T>(
            this IEnumerable<T> source)
            =>
            source.Select(
                value => new object?[] { value });
    }
}
