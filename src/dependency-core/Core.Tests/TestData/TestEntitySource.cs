using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

internal static class TestEntitySource
{
    public static TheoryData<RefType> RefTypes
        =>
        [
            PlusFifteenIdRefType,
            MinusFifteenIdRefType,
            new(null!)
        ];

    public static TheoryData<RecordType> RecordTypes
        =>
        [
            PlusFifteenIdSomeStringNameRecord,
            ZeroIdNullNameRecord,
            new(null!)
        ];

    public static TheoryData<StructType> StructTypes
        =>
        [
            SomeTextStructType,
            new(default)
        ];
}