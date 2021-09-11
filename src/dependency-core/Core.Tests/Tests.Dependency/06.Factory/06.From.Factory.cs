using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void FromFactory_06_FirstIsNull_ExpectArgumentNullException()
        {
            var second = new { Value = decimal.MinusOne };
            var third = PlusFifteenIdRefType;
            var fourth = true;
            var fifth = DateTimeKind.Unspecified;
            var sixth = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    NullStructFactory,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth,
                    () => sixth));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void FromFactory_06_SecondIsNull_ExpectArgumentNullException()
        {
            var first = DateTimeKind.Utc;
            var third = ThreeWhiteSpacesString;
            var fourth = PlusFifteenIdRefType;
            var fifth = LowerSomeTextStructType;
            var sixth = byte.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    NullRecordFactory,
                    () => third,
                    () => fourth,
                    () => fifth,
                    () => sixth));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void FromFactory_06_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = ZeroIdRefType;
            var second = false;
            var fourth = MinusFifteenIdRefType;
            var fifth = WhiteSpaceString;
            var sixth = new object();

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    () => second,
                    NullStructFactory,
                    () => fourth,
                    () => fifth,
                    () => sixth));

            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void FromFactory_06_FourthIsNull_ExpectArgumentNullException()
        {
            var first = byte.MaxValue;
            var second = new object();
            var third = PlusFifteenIdSomeStringNameRecord;
            var fifth = SomeTextStructType;
            var sixth = new[] { int.MinValue, Zero, int.MaxValue };

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    () => second,
                    () => third,
                    NullRefFactory,
                    () => fifth,
                    () => sixth));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void FromFactory_06_FifthIsNull_ExpectArgumentNullException()
        {
            var first = new object();
            var second = SomeTextStructType;
            var third = DateTimeKind.Local;
            var fourth = UpperSomeString;
            var sixth = ZeroIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    NullRecordFactory,
                    () => sixth));

            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void FromFactory_06_SixthIsNull_ExpectArgumentNullException()
        {
            var first = SomeTextStructType;
            var second = byte.MaxValue;
            var third = One;
            var fourth = PlusFifteenIdSomeStringNameRecord;
            var fifth = MixedWhiteSpacesString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth,
                    NullRefFactory));

            Assert.Equal("sixth", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(MinusOne)]
        [InlineData(int.MaxValue)]
        public void FromFactory_06_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
            int? sourceSixth)
        {
            var sourceFirst = new object();
            var sourceSecond = MinusFifteenIdSomeStringNameRecord;
            var sourceThird = SomeTextStructType;
            var sourceFourth = false;
            var sourceFifth = PlusFifteenIdRefType;

            var actual = Dependency.From(
                () => sourceFirst,
                () => sourceSecond,
                () => sourceThird,
                () => sourceFourth,
                () => sourceFifth,
                () => sourceSixth);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth, sourceSixth);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}