using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Fact]
        public void CreateFromFactory_FirstIsNull_ExpectArgumentNullException()
        {
            var second = SomeTextStructType;
            var third = byte.MaxValue;
            var fourth = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RecordType?, StructType?, byte, RefType>.Create(
                    null!,
                    () => second,
                    () => third,
                    () => fourth));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void CreateFromFactory_SecondIsNull_ExpectArgumentNullException()
        {
            var first = LowerSomeTextStructType;
            var third = ZeroIdNullNameRecord;
            var fourth = PlusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<StructType, string?, RecordType?, RefType>.Create(
                    () => first,
                    null!,
                    () => third,
                    () => fourth));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void CreateFromFactory_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdSomeStringNameRecord;
            var second = SomeTextStructType;
            var fourth = WhiteSpaceString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RecordType, StructType?, RefType, string>.Create(
                    () => first,
                    () => second,
                    null!,
                    () => fourth));

            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void CreateFromFactory_FourthIsNull_ExpectArgumentNullException()
        {
            var first = SomeString;
            var second = PlusFifteenIdLowerSomeStringNameRecord;
            var third = ZeroIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<string, RecordType?, RefType?, StructType>.Create(
                    () => first,
                    () => second,
                    () => third,
                    null!));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void CreateFromFactory_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
            RefType? sourceFourth)
        {
            var sourceFirst = SomeTextStructType;
            var sourceSecond = MinusFifteenIdNullNameRecord;
            var sourceThird = decimal.MinusOne;

            var actual = Dependency<StructType?, RecordType?, decimal, RefType?>.Create(
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