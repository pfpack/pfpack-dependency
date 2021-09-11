using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Fact]
        public void From_Resolver_FirstIsNull_ExpectArgumentNullException()
        {
            var second = decimal.MinValue;
            var third = SomeTextStructType;
            var fourth = default(RecordType?);
            var fifth = new object();
            var sixth = DateTimeKind.Utc;
            var seventh = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<string?, decimal, StructType?, RecordType?, object, DateTimeKind, RefType>.From(
                    null!,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void From_Resolver_SecondIsNull_ExpectArgumentNullException()
        {
            var first = LowerSomeTextStructType;
            var third = long.MinValue;
            var fourth = MinusFifteenIdSomeStringNameRecord;
            var fifth = new object();
            var sixth = DateTimeKind.Local;
            var seventh = decimal.One;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<StructType?, RefType, long, RecordType?, object, DateTimeKind?, decimal>.From(
                    _ => first,
                    null!,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void From_Resolver_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = true;
            var second = LowerSomeString;
            var fourth = PlusFifteenIdRefType;
            var fifth = SomeTextStructType;
            var sixth = ZeroIdNullNameRecord;
            var seventh = long.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<bool, string, object[]?, RefType?, StructType?, RecordType?, long>.From(
                    _ => first,
                    _ => second,
                    null!,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh));

            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void From_Resolver_FourthIsNull_ExpectArgumentNullException()
        {
            var first = new object();
            var second = long.MinValue;
            var third = MinusFifteenIdSomeStringNameRecord;
            var fifth = PlusFifteenIdRefType;
            var sixth = SomeTextStructType;
            var seventh = One;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<object, long, RecordType, decimal, RefType, StructType?, int>.From(
                    _ => first,
                    _ => second,
                    _ => third,
                    null!,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void From_Resolver_FifthIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdRefType;
            var second = decimal.MinusOne;
            var third = new object();
            var fourth = PlusFifteen;
            var sixth = ZeroIdNullNameRecord;
            var seventh = DateTimeKind.Unspecified;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RefType?, decimal, object, int, StructType?, RecordType, DateTimeKind>.From(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    null!,
                    _ => sixth,
                    _ => seventh));

            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void From_Resolver_SixthIsNull_ExpectArgumentNullException()
        {
            var first = default(int?);
            var second = UpperSomeString;
            var third = LowerSomeTextStructType;
            var fourth = decimal.MinValue;
            var fifth = PlusFifteenIdRefType;
            var seventh = MinusFifteenIdNullNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<int?, string, StructType, decimal, RefType?, bool, RecordType>.From(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    null!,
                    _ => seventh));

            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void From_Resolver_SeventhIsNull_ExpectArgumentNullException()
        {
            var first = default(RefType?);
            var second = new object();
            var third = WhiteSpaceString;
            var fourth = SomeTextStructType;
            var fifth = false;
            var sixth = long.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RefType?, object, string?, StructType, bool, long, RecordType>.From(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    null!));

            Assert.Equal("seventh", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void From_Resolver_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
            RecordType? sourceSeventh)
        {
            var sourceFirst = default(long?);
            var sourceSecond = LowerSomeTextStructType;
            var sourceThird = new { Value = decimal.One };
            var sourceFourth = MinusFifteenIdRefType;
            var sourceFifth = UpperSomeString;
            var sourceSixth = true;

            var actual = Dependency<long?, StructType, object, RefType?, string, bool, RecordType?>.From(
                _ => sourceFirst,
                _ => sourceSecond,
                _ => sourceThird,
                _ => sourceFourth,
                _ => sourceFifth,
                _ => sourceSixth,
                _ => sourceSeventh);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth, sourceSixth, sourceSeventh);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}