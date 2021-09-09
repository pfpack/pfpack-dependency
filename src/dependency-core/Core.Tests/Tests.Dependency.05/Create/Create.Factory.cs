using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Fact]
        public void CreateFromFactory_FirstIsNull_ExpectArgumentNullException()
        {
            var second = ThreeWhiteSpacesString;
            var third = MinusFifteenIdRefType;
            var fourth = SomeTextStructType;
            var fifth = PlusFifteenIdSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<DateTimeKind?, string, RefType?, StructType, RecordType>.Create(
                    null!,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void CreateFromFactory_SecondIsNull_ExpectArgumentNullException()
        {
            var first = UpperSomeString;
            var third = One;
            var fourth = MinusFifteenIdSomeStringNameRecord;
            var fifth = LowerSomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<string, RefType, int, RecordType?, StructType>.Create(
                    () => first,
                    null!,
                    () => third,
                    () => fourth,
                    () => fifth));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void CreateFromFactory_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = new { Name = SomeString };
            var second = MinusFifteenIdRefType;
            var fourth = long.MaxValue;
            var fifth = ZeroIdNullNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<object?, RefType, StructType?, long, RecordType>.Create(
                    () => first,
                    () => second,
                    null!,
                    () => fourth,
                    () => fifth));

            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void CreateFromFactory_FourthIsNull_ExpectArgumentNullException()
        {
            var first = default(int?);
            var second = PlusFifteenIdRefType;
            var third = LowerSomeTextStructType;
            var fifth = new object();

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<int?, RefType, StructType, RecordType?, object>.Create(
                    () => first,
                    () => second,
                    () => third,
                    null!,
                    () => fifth));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void CreateFromFactory_FifthIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdSomeStringNameRecord;
            var second = One;
            var third = PlusFifteenIdRefType;
            var fourth = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RecordType?, int, RefType, StructType?, string>.Create(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    null!));

            Assert.Equal("fifth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void CreateFromFactory_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
            StructType sourceFifth)
        {
            var sourceFirst = MinusFifteenIdRefType;
            var sourceSecond = EmptyString;
            var sourceThird = MinusOne;
            var sourceFourth = PlusFifteenIdLowerSomeStringNameRecord;

            var actual = Dependency<RefType, string?, int?, RecordType, StructType>.Create(
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