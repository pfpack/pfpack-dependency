using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Fact]
        public void FromFactory_FirstIsNull_ExpectArgumentNullException()
        {
            var second = PlusFifteenIdSomeStringNameRecord;
            var third = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RefType, RecordType, StructType?>.From(
                    null!,
                    () => second,
                    () => third));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void FromFactory_SecondIsNull_ExpectArgumentNullException()
        {
            var first = ZeroIdNullNameRecord;
            var third = PlusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RecordType?, StructType?, RefType>.From(
                    () => first,
                    null!,
                    () => third));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void FromFactory_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = LowerSomeTextStructType;
            var second = PlusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<StructType, RefType?, RecordType?>.From(
                    () => first,
                    () => second,
                    null!));

            Assert.Equal("third", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(byte.MinValue)]
        [InlineData(byte.MaxValue)]
        public void FromFactory_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
            byte? sourceThird)
        {
            var sourceFirst = PlusFifteenIdRefType;
            var sourceSecond = LowerSomeTextStructType;

            var actual = Dependency<RefType?, StructType, byte?>.From(
                () => sourceFirst,
                () => sourceSecond,
                () => sourceThird);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}