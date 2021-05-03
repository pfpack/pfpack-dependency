#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void Create_08_FirstIsNull_ExpectArgumentNullException()
        {
            var second = MinusFifteen;
            var third = SomeString;
            var fourth = PlusFifteenIdLowerSomeStringNameRecord;
            var fifth = new object();
            var sixth = DateTimeKind.Unspecified;
            var seventh = byte.MaxValue;
            var rest = ZeroIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    NullRecordResolver,
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
        public void Create_08_SecondIsNull_ExpectArgumentNullException()
        {
            var first = PlusFifteenIdSomeStringNameRecord;
            var third = new { Id = PlusFifteen, Value = decimal.MinusOne };
            var fourth = DateTimeKind.Local;
            var fifth = SomeTextStructType;
            var sixth = MinusFifteenIdRefType;
            var seventh = (MinusFifteen, UpperSomeString, false, LowerSomeString);
            var rest = decimal.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    NullRecordResolver,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh,
                    _ => rest));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void Create_08_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = ZeroIdRefType;
            var second = decimal.MinusOne;
            var fourth = new object();
            var fifth = PlusFifteen;
            var sixth = MinusFifteenIdSomeStringNameRecord;
            var seventh = WhiteSpaceString;
            var rest = (SomeString, true, TabString);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    _ => second,
                    NullRecordResolver,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh,
                    _ => rest));

            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void Create_08_FourthIsNull_ExpectArgumentNullException()
        {
            var first = DateTimeKind.Utc;
            var second = SomeTextStructType;
            var third = PlusFifteenIdRefType;
            var fifth = MinusFifteenIdNullNameRecord;
            var sixth = Zero;
            var seventh = (PlusFifteen, decimal.One);
            var rest = TabString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    NullRecordResolver,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh,
                    _ => rest));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void Create_08_FifthIsNull_ExpectArgumentNullException()
        {
            var first = PlusFifteenIdLowerSomeStringNameRecord;
            var second = PlusFifteenIdRefType;
            var third = new object();
            var fourth = byte.MaxValue;
            var sixth = DateTimeKind.Unspecified;
            var seventh = decimal.MaxValue;
            var rest = LowerSomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    NullRecordResolver,
                    _ => sixth,
                    _ => seventh,
                    _ => rest));

            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void Create_08_SixthIsNull_ExpectArgumentNullException()
        {
            var first = true;
            var second = decimal.MinValue;
            var third = new { Name = UpperSomeString };
            var fourth = MinusFifteenIdNullNameRecord;
            var fifth = ZeroIdRefType;
            var seventh = SomeTextStructType;
            var rest = PlusFifteen;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    NullRecordResolver,
                    _ => seventh,
                    _ => rest));

            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void Create_08_SeventhIsNull_ExpectArgumentNullException()
        {
            var first = ZeroIdNullNameRecord;
            var second = UpperSomeString;
            var third = (SomeString, MinusFifteen, false);
            var fourth = LowerSomeTextStructType;
            var fifth = new object();
            var sixth = decimal.MinusOne;
            var rest = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    NullRecordResolver,
                    _ => rest));

            Assert.Equal("seventh", ex.ParamName);
        }

        [Fact]
        public void Create_08_RestIsNull_ExpectArgumentNullException()
        {
            var first = ThreeWhiteSpacesString;
            var second = SomeTextStructType;
            var third = MinusFifteenIdRefType;
            var fourth = Array.Empty<DateTimeOffset>();
            var fifth = PlusFifteenIdLowerSomeStringNameRecord;
            var sixth = new { Id = PlusFifteen };
            var seventh = byte.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh,
                    NullRecordResolver));

            Assert.Equal("rest", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void Create_08_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
            RecordType? sourceRest)
        {
            var sourceFirst = decimal.MaxValue;
            var sourceSecond = LowerSomeTextStructType;
            var sourceThird = new object();
            var sourceFourth = TabString;
            var sourceFifth = ZeroIdRefType;
            var sourceSixth = DateTimeKind.Utc;
            var sourceSeventh = true;

            var actual = Dependency.Create(
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