using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void CreateFromFactory_04_FirstIsNull_ExpectArgumentNullException()
        {
            var second = MinusFifteenIdRefType;
            var third = One;
            var fourth = PlusFifteenIdSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    NullStructFactory,
                    () => second,
                    () => third,
                    () => fourth));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void CreateFromFactory_04_SecondIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdRefType;
            var third = LowerSomeTextStructType;
            var fourth = new object();

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    () => first,
                    NullRecordFactory,
                    () => third,
                    () => fourth));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void CreateFromFactory_04_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = SomeString;
            var second = ZeroIdNullNameRecord;
            var fourth = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    () => first,
                    () => second,
                    NullRefFactory,
                    () => fourth));

            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void CreateFromFactory_04_FourthIsNull_ExpectArgumentNullException()
        {
            var first = SomeTextStructType;
            var second = ZeroIdRefType;
            var third = DateTimeKind.Unspecified;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
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
        public void CreateFromFactory_04_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
            string? sourceFourth)
        {
            var sourceFirst = PlusFifteenIdRefType;
            var sourceSecond = ZeroIdNullNameRecord;
            var sourceThird = LowerSomeTextStructType;

            var actual = Dependency.Create(
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