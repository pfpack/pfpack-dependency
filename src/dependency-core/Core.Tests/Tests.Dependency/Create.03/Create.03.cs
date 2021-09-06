using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void Create_03_FirstIsNull_ExpectArgumentNullException()
        {
            var second = SomeTextStructType;
            var third = PlusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    NullRecordFactory,
                    () => second,
                    () => third));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void Create_03_SecondIsNull_ExpectArgumentNullException()
        {
            var first = PlusFifteenIdSomeStringNameRecord;
            var third = ZeroIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    () => first,
                    NullStructFactory,
                    () => third));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void Create_03_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdNullNameRecord;
            var second = LowerSomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    () => first,
                    () => second,
                    NullRefFactory));

            Assert.Equal("third", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void Create_03_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
            StructType sourceThird)
        {
            var sourceFirst = MinusFifteenIdSomeStringNameRecord;
            var sourceSecond = PlusFifteenIdRefType;

            var actual = Dependency.Create(
                () => sourceFirst,
                () => sourceSecond,
                () => sourceThird);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}