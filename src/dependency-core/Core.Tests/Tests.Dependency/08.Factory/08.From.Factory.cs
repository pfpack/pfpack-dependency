using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void From_Factory_08_FirstIsNull_ExpectArgumentNullException()
        {
            var second = PlusFifteen;
            var third = new object();
            var fourth = decimal.One;
            var fifth = PlusFifteenIdRefType;
            var sixth = MinusFifteenIdNullNameRecord;
            var seventh = long.MaxValue;
            var rest = false;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    NullStructFactory,
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
        public void From_Factory_08_SecondIsNull_ExpectArgumentNullException()
        {
            var first = DateTimeKind.Utc;
            var third = SomeTextStructType;
            var fourth = new object();
            var fifth = long.MinValue;
            var sixth = MinusOne;
            var seventh = true;
            var rest = MinusFifteenIdSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    NullRefFactory,
                    () => third,
                    () => fourth,
                    () => fifth,
                    () => sixth,
                    () => seventh,
                    () => rest));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void From_Factory_08_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = Array.Empty<DateTime>();
            var second = default(object);
            var fourth = byte.MaxValue;
            var fifth = SomeTextStructType;
            var sixth = TabString;
            var seventh = ZeroIdRefType;
            var rest = decimal.MinusOne;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    () => second,
                    NullRecordFactory,
                    () => fourth,
                    () => fifth,
                    () => sixth,
                    () => seventh,
                    () => rest));

            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void From_Factory_08_FourthIsNull_ExpectArgumentNullException()
        {
            var first = true;
            var second = DateTimeKind.Local;
            var third = long.MaxValue;
            var fifth = new object();
            var sixth = decimal.One;
            var seventh = SomeTextStructType;
            var rest = MinusFifteenIdNullNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    () => second,
                    () => third,
                    NullRefFactory,
                    () => fifth,
                    () => sixth,
                    () => seventh,
                    () => rest));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void From_Factory_08_FifthIsNull_ExpectArgumentNullException()
        {
            var first = ThreeWhiteSpacesString;
            var second = int.MinValue;
            var third = ZeroIdNullNameRecord;
            var fourth = new object();
            var sixth = false;
            var seventh = PlusFifteenIdRefType;
            var rest = decimal.One;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    NullStructFactory,
                    () => sixth,
                    () => seventh,
                    () => rest));

            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void From_Factory_08_SixthIsNull_ExpectArgumentNullException()
        {
            var first = Array.Empty<long>();
            var second = new { Id = One, Name = SomeString };
            var third = MinusFifteenIdSomeStringNameRecord;
            var fourth = DateTimeKind.Unspecified;
            var fifth = LowerSomeTextStructType;
            var seventh = true;
            var rest = (decimal.MaxValue, long.MinValue);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth,
                    NullRefFactory,
                    () => seventh,
                    () => rest));

            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void From_Factory_08_SeventhIsNull_ExpectArgumentNullException()
        {
            var first = byte.MaxValue;
            var second = ZeroIdNullNameRecord;
            var third = new object();
            var fourth = decimal.MinValue;
            var fifth = DateTimeKind.Utc;
            var sixth = SomeTextStructType;
            var rest = new[] { int.MinValue, int.MaxValue, One, MinusOne, PlusFifteen };

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth,
                    () => sixth,
                    NullRefFactory,
                    () => rest));

            Assert.Equal("seventh", ex.ParamName);
        }

        [Fact]
        public void From_Factory_08_RestIsNull_ExpectArgumentNullException()
        {
            var first = true;
            var second = MinusFifteenIdRefType;
            var third = new { TextReader= UpperSomeString };
            var fourth = One;
            var fifth = DateTimeKind.Unspecified;
            var sixth = long.MinValue;
            var seventh = LowerSomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth,
                    () => sixth,
                    () => seventh,
                    NullRecordFactory));

            Assert.Equal("rest", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void From_Factory_08_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
            RefType sourceRest)
        {
            var sourceFirst = new { Value = decimal.One };
            var sourceSecond = MinusFifteenIdNullNameRecord;
            var sourceThird = SomeTextStructType;
            var sourceFourth = long.MaxValue;
            var sourceFifth = false;
            var sourceSixth = new[] { byte.MaxValue };
            var sourceSeventh = UpperSomeString;

            var actual = Dependency.From(
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