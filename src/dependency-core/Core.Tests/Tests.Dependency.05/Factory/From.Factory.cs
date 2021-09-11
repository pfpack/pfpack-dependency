using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Fact]
        public void FromFactory_FirstIsNull_ExpectArgumentNullException()
        {
            var second = ThreeWhiteSpacesString;
            var third = MinusFifteenIdRefType;
            var fourth = SomeTextStructType;
            var fifth = PlusFifteenIdSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<DateTimeKind?, string, RefType?, StructType, RecordType>.From(
                    null!,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void FromFactory_SecondIsNull_ExpectArgumentNullException()
        {
            var first = UpperSomeString;
            var third = One;
            var fourth = MinusFifteenIdSomeStringNameRecord;
            var fifth = LowerSomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<string, RefType, int, RecordType?, StructType>.From(
                    () => first,
                    null!,
                    () => third,
                    () => fourth,
                    () => fifth));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void FromFactory_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = new { Name = SomeString };
            var second = MinusFifteenIdRefType;
            var fourth = long.MaxValue;
            var fifth = ZeroIdNullNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<object?, RefType, StructType?, long, RecordType>.From(
                    () => first,
                    () => second,
                    null!,
                    () => fourth,
                    () => fifth));

            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void FromFactory_FourthIsNull_ExpectArgumentNullException()
        {
            var first = default(int?);
            var second = PlusFifteenIdRefType;
            var third = LowerSomeTextStructType;
            var fifth = new object();

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<int?, RefType, StructType, RecordType?, object>.From(
                    () => first,
                    () => second,
                    () => third,
                    null!,
                    () => fifth));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void FromFactory_FifthIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdSomeStringNameRecord;
            var second = One;
            var third = PlusFifteenIdRefType;
            var fourth = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RecordType?, int, RefType, StructType?, string>.From(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    null!));

            Assert.Equal("fifth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void FromFactory_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
            StructType sourceFifth)
        {
            var sourceFirst = MinusFifteenIdRefType;
            var sourceSecond = EmptyString;
            var sourceThird = MinusOne;
            var sourceFourth = PlusFifteenIdLowerSomeStringNameRecord;

            var actual = Dependency<RefType, string?, int?, RecordType, StructType>.From(
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