using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void Create_07_FirstIsNull_ExpectArgumentNullException()
        {
            var second = UpperSomeString;
            var third = byte.MaxValue;
            var fourth = MinusFifteenIdRefType;
            var fifth = new[] { decimal.One };
            var sixth = false;
            var seventh = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    NullRecordFactory,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth,
                    () => sixth,
                    () => seventh));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void Create_07_SecondIsNull_ExpectArgumentNullException()
        {
            var first = decimal.MaxValue;
            var third = PlusFifteenIdRefType;
            var fourth = byte.MaxValue;
            var fifth = MinusFifteenIdSomeStringNameRecord;
            var sixth = new object();
            var seventh = DateTimeKind.Unspecified;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    () => first,
                    NullStructFactory,
                    () => third,
                    () => fourth,
                    () => fifth,
                    () => sixth,
                    () => seventh));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void Create_07_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdSomeStringNameRecord;
            var second = DateTimeKind.Utc;
            var fourth = ThreeWhiteSpacesString;
            var fifth = new object();
            var sixth = SomeTextStructType;
            var seventh = decimal.MinusOne;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    () => first,
                    () => second,
                    NullRefFactory,
                    () => fourth,
                    () => fifth,
                    () => sixth,
                    () => seventh));

            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void Create_07_FourthIsNull_ExpectArgumentNullException()
        {
            var first = Array.Empty<DateTimeOffset?>();
            var second = LowerSomeTextStructType;
            var third = default(string);
            var fifth = int.MinValue;
            var sixth = ZeroIdRefType;
            var seventh = false;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    () => first,
                    () => second,
                    () => third,
                    NullRecordFactory,
                    () => fifth,
                    () => sixth,
                    () => seventh));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void Create_07_FifthIsNull_ExpectArgumentNullException()
        {
            var first = TabString;
            var second = PlusFifteenIdSomeStringNameRecord;
            var third = NullTextStructType;
            var fourth = true;
            var sixth = PlusFifteen;
            var seventh = new object();

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    NullRefFactory,
                    () => sixth,
                    () => seventh));

            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void Create_07_SixthIsNull_ExpectArgumentNullException()
        {
            var first = DateTimeKind.Utc;
            var second = new[] { long.MinValue };
            var third = decimal.MaxValue;
            var fourth = SomeTextStructType;
            var fifth = MinusOne;
            var seventh = PlusFifteenIdSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth,
                    NullRecordFactory,
                    () => seventh));

            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void Create_07_SeventhIsNull_ExpectArgumentNullException()
        {
            var first = ZeroIdNullNameRecord;
            var second = Array.Empty<decimal>();
            var third = long.MaxValue;
            var fourth = false;
            var fifth = MinusFifteenIdRefType;
            var sixth = SomeString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth,
                    () => sixth,
                    NullStructFactory));

            Assert.Equal("seventh", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(SomeString)]
        public void Create_07_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
            string sourceSeventh)
        {
            var sourceFirst = PlusFifteenIdRefType;
            var sourceSecond = long.MaxValue;
            var sourceThird = new object();
            var sourceFourth = MinusFifteenIdNullNameRecord;
            var sourceFifth = PlusFifteen;
            var sourceSixth = SomeTextStructType;

            var actual = Dependency.Create(
                () => sourceFirst,
                () => sourceSecond,
                () => sourceThird,
                () => sourceFourth,
                () => sourceFifth,
                () => sourceSixth,
                () => sourceSeventh);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth, sourceSixth, sourceSeventh);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}