using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Fact]
        public void From_Factory_FirstIsNull_ExpectArgumentNullException()
        {
            var second = ThreeWhiteSpacesString;
            var third = decimal.MinValue;
            var fourth = MinusFifteenIdNullNameRecord;
            var fifth = new object();
            var sixth = LowerSomeTextStructType;
            var seventh = DateTimeKind.Utc;
            var rest = PlusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<bool?, string, decimal, RecordType?, object, StructType, DateTimeKind?, RefType>.From(
                    null!,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth,
                    () => sixth,
                    () => seventh,
                    () => rest));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void From_Factory_SecondIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdRefType;
            var third = long.MaxValue;
            var fourth = new object();
            var fifth = SomeTextStructType;
            var sixth = UpperSomeString;
            var seventh = decimal.One;
            var rest = DateTimeKind.Local;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RefType, RecordType, long, object, StructType?, string?, decimal, DateTimeKind>.From(
                    () => first,
                    null!,
                    () => third,
                    () => fourth,
                    () => fifth,
                    () => sixth,
                    () => seventh,
                    () => rest));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void From_Factory_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = new { Text = WhiteSpaceString };
            var second = SomeTextStructType;
            var fourth = EmptyString;
            var fifth = PlusFifteenIdLowerSomeStringNameRecord;
            var sixth = default(decimal?);
            var seventh = ZeroIdRefType;
            var rest = true;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<object, StructType, DateTime, string?, RecordType?, decimal?, RefType, bool>.From(
                    () => first,
                    () => second,
                    null!,
                    () => fourth,
                    () => fifth,
                    () => sixth,
                    () => seventh,
                    () => rest));

            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void From_Factory_FourthIsNull_ExpectArgumentNullException()
        {
            var first = UpperSomeString;
            var second = new object();
            var third = MinusFifteenIdNullNameRecord;
            var fifth = LowerSomeTextStructType;
            var sixth = PlusFifteenIdRefType;
            var seventh = int.MaxValue;
            var rest = long.MinValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<string, object, RecordType?, double, StructType, RefType, int, long?>.From(
                    () => first,
                    () => second,
                    () => third,
                    null!,
                    () => fifth,
                    () => sixth,
                    () => seventh,
                    () => rest));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void From_Factory_FifthIsNull_ExpectArgumentNullException()
        {
            var first = LowerSomeTextStructType;
            var second = decimal.MinusOne;
            var third = PlusFifteenIdRefType;
            var fourth = MinusFifteenIdNullNameRecord;
            var sixth = false;
            var seventh = DateTimeKind.Utc;
            var rest = new { Id = One };

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<StructType, decimal, RefType?, RecordType?, string?, bool, DateTimeKind, object?>.From(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    null!,
                    () => sixth,
                    () => seventh,
                    () => rest));

            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void From_Factory_SixthIsNull_ExpectArgumentNullException()
        {
            var first = int.MinValue;
            var second = MinusFifteenIdRefType;
            var third = PlusFifteenIdLowerSomeStringNameRecord;
            var fourth = long.MaxValue;
            var fifth = new { Id = One, Name = UpperSomeString };
            var seventh = EmptyString;
            var rest = decimal.MinusOne;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<int, RefType, RecordType?, long, object, StructType, string?, decimal>.From(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth,
                    null!,
                    () => seventh,
                    () => rest));

            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void From_Factory_SeventhIsNull_ExpectArgumentNullException()
        {
            var first = decimal.MaxValue;
            var second = true;
            var third = new object();
            var fourth = new[] { long.MinValue };
            var fifth = SomeTextStructType;
            var sixth = PlusFifteenIdSomeStringNameRecord;
            var rest = DateTimeKind.Unspecified;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<decimal?, bool, object, long[], StructType, RecordType?, RefType?, DateTimeKind>.From(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth,
                    () => sixth,
                    null!,
                    () => rest));

            Assert.Equal("seventh", ex.ParamName);
        }

        [Fact]
        public void From_Factory_RestIsNull_ExpectArgumentNullException()
        {
            var first = new object();
            var second = LowerSomeString;
            var third = SomeTextStructType;
            var fourth = ZeroIdRefType;
            var fifth = default(bool?);
            var sixth = PlusFifteenIdSomeStringNameRecord;
            var seventh = DateTimeKind.Utc;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<object?, string, StructType, RefType, bool?, RecordType, DateTimeKind, long?>.From(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth,
                    () => sixth,
                    () => seventh,
                    null!));

            Assert.Equal("rest", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(SomeString)]
        public void From_Factory_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
            string? sourceRest)
        {
            var sourceFirst = SomeTextStructType;
            var sourceSecond = MinusFifteenIdRefType;
            var sourceThird = new { Id = One };
            var sourceFourth = false;
            var sourceFifth = Zero;
            var sourceSixth = PlusFifteenIdSomeStringNameRecord;
            var sourceSeventh = long.MaxValue;

            var actual = Dependency<StructType, RefType, object?, bool, int?, RecordType, long, string?>.From(
                () => sourceFirst,
                () => sourceSecond,
                () => sourceThird,
                () => sourceFourth,
                () => sourceFifth,
                () => sourceSixth,
                () => sourceSeventh,
                () => sourceRest);

            var actualValue = actual.Resolve();

            var expectedValue = ((sourceFirst, sourceSecond, sourceThird, sourceFourth), (sourceFifth, sourceSixth, sourceSeventh, sourceRest));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}