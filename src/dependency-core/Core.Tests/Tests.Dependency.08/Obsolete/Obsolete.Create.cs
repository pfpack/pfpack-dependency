using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Fact]
        public void Obsolete_Create_FirstIsNull_ExpectArgumentNullException()
        {
            var second = PlusFifteenIdLowerSomeStringNameRecord;
            var third = MinusFifteen;
            var fourth = new { Name = SomeString };
            var fifth = SomeTextStructType;
            var sixth = decimal.MaxValue;
            var seventh = false;
            var rest = LowerSomeString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RefType, RecordType, int, object, StructType, decimal, bool, string>.Create(
                    null!,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh,
                    _ => rest));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void Obsolete_Create_SecondIsNull_ExpectArgumentNullException()
        {
            var first = DateTimeKind.Unspecified;
            var third = EmptyString;
            var fourth = (int?)int.MaxValue;
            var fifth = MinusFifteenIdRefType;
            var sixth = decimal.MinusOne;
            var seventh = true;
            var rest = new object();

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<DateTimeKind, StructType, string, int?, RefType, decimal, bool, object>.Create(
                    _ => first,
                    null!,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh,
                    _ => rest));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void Obsolete_Create_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = MinusOne;
            var second = ZeroIdRefType;
            var fourth = long.MaxValue;
            var fifth = false;
            var sixth = new object();
            var seventh = LowerSomeTextStructType;
            var rest = MinusFifteenIdNullNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<int, RefType?, string, long?, bool?, object?, StructType, RecordType>.Create(
                    _ => first,
                    _ => second,
                    null!,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh,
                    _ => rest));

            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void Obsolete_Create_FourthIsNull_ExpectArgumentNullException()
        {
            var first = SomeTextStructType;
            var second = new[] { LowerSomeString, MixedWhiteSpacesString, SomeString };
            var third = new object();
            var fifth = DateTimeKind.Local;
            var sixth = decimal.One;
            var seventh = true;
            var rest = PlusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<StructType?, string[]?, object, RecordType?, DateTimeKind, decimal?, bool, RefType>.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    null!,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh,
                    _ => rest));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void Obsolete_Create_FifthIsNull_ExpectArgumentNullException()
        {
            var first = false;
            var second = ZeroIdNullNameRecord;
            var third = MinusFifteen;
            var fourth = LowerSomeTextStructType;
            var sixth = (long?)null;
            var seventh = MinusFifteenIdRefType;
            var rest = UpperSomeString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<bool, RecordType?, int, StructType, object[], long?, RefType, string>.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    null!,
                    _ => sixth,
                    _ => seventh,
                    _ => rest));

            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void Obsolete_Create_SixthIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdSomeStringNameRecord;
            var second = DateTimeKind.Utc;
            var third = SomeString;
            var fourth = new object();
            var fifth = SomeTextStructType;
            var seventh = int.MaxValue;
            var rest = ZeroIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RecordType, DateTimeKind, string?, object, StructType, decimal, int, RefType?>.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    null!,
                    _ => seventh,
                    _ => rest));

            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void Obsolete_Create_SeventhIsNull_ExpectArgumentNullException()
        {
            var first = LowerSomeTextStructType;
            var second = long.MinValue;
            var third = DateTimeKind.Unspecified;
            var fourth = false;
            var fifth = PlusFifteenIdLowerSomeStringNameRecord;
            var sixth = MinusFifteenIdRefType;
            var rest = LowerSomeString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<StructType?, long, DateTimeKind, bool?, RecordType, RefType, decimal[]?, string>.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    null!,
                    _ => rest));

            Assert.Equal("seventh", ex.ParamName);
        }

        [Fact]
        public void Obsolete_Create_RestIsNull_ExpectArgumentNullException()
        {
            var first = decimal.One;
            var second = new { Value = long.MaxValue };
            var third = PlusFifteenIdSomeStringNameRecord;
            var fourth = UpperSomeString;
            var fifth = MinusOne;
            var sixth = SomeTextStructType;
            var seventh = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<decimal, object, RecordType, string?, int?, StructType, RefType?, DateTimeKind>.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh,
                    null!));

            Assert.Equal("rest", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void Obsolete_Create_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
            StructType sourceRest)
        {
            var sourceFirst = new object();
            var sourceSecond = UpperSomeString;
            var sourceThird = MinusFifteenIdSomeStringNameRecord;
            var sourceFourth = PlusFifteen;
            var sourceFifth = Array.Empty<DateTimeOffset?>();
            var sourceSixth = long.MinValue;
            var sourceSeventh = PlusFifteenIdRefType;

            var actual = Dependency<object, string?, RecordType?, int, DateTimeOffset?[], long, RefType, StructType>.Create(
                _ => sourceFirst,
                _ => sourceSecond,
                _ => sourceThird,
                _ => sourceFourth,
                _ => sourceFifth,
                _ => sourceSixth,
                _ => sourceSeventh,
                _ => sourceRest);

            var actualValue = actual.Resolve();

            var expectedValue = ((sourceFirst, sourceSecond, sourceThird, sourceFourth), (sourceFifth, sourceSixth, sourceSeventh, sourceRest));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}