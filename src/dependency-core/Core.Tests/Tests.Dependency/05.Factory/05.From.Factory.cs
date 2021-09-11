using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void FromFactory_05_FirstIsNull_ExpectArgumentNullException()
        {
            var second = SomeTextStructType;
            var third = new object();
            var fourth = MinusFifteenIdRefType;
            var fifth = byte.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    NullRecordFactory,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void FromFactory_05_SecondIsNull_ExpectArgumentNullException()
        {
            var first = EmptyString;
            var third = MinusFifteenIdNullNameRecord;
            var fourth = MinusOne;
            var fifth = new { Value = decimal.MaxValue };

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    NullRefFactory,
                    () => third,
                    () => fourth,
                    () => fifth));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void FromFactory_05_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = long.MinValue;
            var second = PlusFifteenIdRefType;
            var fourth = DateTimeKind.Utc;
            var fifth = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    () => second,
                    NullRecordFactory,
                    () => fourth,
                    () => fifth));

            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void FromFactory_05_FourthIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdRefType;
            var second = true;
            var third = new object();
            var fifth = ZeroIdNullNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    () => second,
                    () => third,
                    NullStructFactory,
                    () => fifth));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void FromFactory_05_FifthIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdSomeStringNameRecord;
            var second = false;
            var third = long.MaxValue;
            var fourth = ZeroIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    NullStructFactory));

            Assert.Equal("fifth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void FromFactory_05_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
            RecordType sourceFifth)
        {
            var sourceFirst = SomeTextStructType;
            var sourceSecond = MinusFifteenIdRefType;
            var sourceThird = byte.MaxValue;
            var sourceFourth = UpperSomeString;

            var actual = Dependency.From(
                () => sourceFirst,
                () => sourceSecond,
                () => sourceThird,
                () => sourceFourth,
                () => sourceFifth);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}