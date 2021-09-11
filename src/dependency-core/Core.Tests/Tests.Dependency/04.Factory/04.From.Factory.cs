using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void FromFactory_04_FirstIsNull_ExpectArgumentNullException()
        {
            var second = MinusFifteenIdRefType;
            var third = One;
            var fourth = PlusFifteenIdSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    NullStructFactory,
                    () => second,
                    () => third,
                    () => fourth));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void FromFactory_04_SecondIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdRefType;
            var third = LowerSomeTextStructType;
            var fourth = new object();

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    NullRecordFactory,
                    () => third,
                    () => fourth));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void FromFactory_04_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = SomeString;
            var second = ZeroIdNullNameRecord;
            var fourth = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    () => second,
                    NullRefFactory,
                    () => fourth));

            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void FromFactory_04_FourthIsNull_ExpectArgumentNullException()
        {
            var first = SomeTextStructType;
            var second = ZeroIdRefType;
            var third = DateTimeKind.Unspecified;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    () => second,
                    () => third,
                    NullRecordFactory));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(SomeString)]
        public void FromFactory_04_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
            string? sourceFourth)
        {
            var sourceFirst = PlusFifteenIdRefType;
            var sourceSecond = ZeroIdNullNameRecord;
            var sourceThird = LowerSomeTextStructType;

            var actual = Dependency.From(
                () => sourceFirst,
                () => sourceSecond,
                () => sourceThird,
                () => sourceFourth);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}