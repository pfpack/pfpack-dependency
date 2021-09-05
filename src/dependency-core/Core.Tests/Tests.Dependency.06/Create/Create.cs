using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Fact]
        public void Create_FirstIsNull_ExpectArgumentNullException()
        {
            var second = PlusFifteenIdLowerSomeStringNameRecord;
            var third = ZeroIdRefType;
            var fourth = MinusOne;
            var fifth = UpperSomeString;
            var sixth = new object();

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<StructType, RecordType, RefType, int?, string?, object>.Create(
                    null!,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth,
                    () => sixth));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void Create_SecondIsNull_ExpectArgumentNullException()
        {
            var first = PlusFifteenIdRefType;
            var third = default(object?);
            var fourth = ZeroIdNullNameRecord;
            var fifth = TabString;
            var sixth = LowerSomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RefType?, DateTimeKind?, object?, RecordType, string, StructType>.Create(
                    () => first,
                    null!,
                    () => third,
                    () => fourth,
                    () => fifth,
                    () => sixth));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void Create_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdSomeStringNameRecord;
            var second = long.MaxValue;
            var fourth = SomeTextStructType;
            var fifth = EmptyString;
            var sixth = false;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RecordType, long, RefType, StructType?, string?, bool?>.Create(
                    () => first,
                    () => second,
                    null!,
                    () => fourth,
                    () => fifth,
                    () => sixth));

            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void Create_FourthIsNull_ExpectArgumentNullException()
        {
            var first = LowerSomeTextStructType;
            var second = new object();
            var third = byte.MaxValue;
            var fifth = PlusFifteenIdRefType;
            var sixth = ZeroIdNullNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<StructType?, object?, byte, string?, RefType, RecordType?>.Create(
                    () => first,
                    () => second,
                    () => third,
                    null!,
                    () => fifth,
                    () => sixth));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void Create_FifthIsNull_ExpectArgumentNullException()
        {
            var first = decimal.MinValue;
            var second = MixedWhiteSpacesString;
            var third = SomeTextStructType;
            var fourth = DateTimeKind.Utc;
            var sixth = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<decimal, string?, StructType?, DateTimeKind?, RecordType, RefType>.Create(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    null!,
                    () => sixth));

            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void Create_SixthIsNull_ExpectArgumentNullException()
        {
            var first = PlusFifteenIdLowerSomeStringNameRecord;
            var second = false;
            var third = EmptyString;
            var fourth = MinusFifteenIdRefType;
            var fifth = default(StructType?);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RecordType?, bool?, string, RefType, StructType?, DateTimeKind>.Create(
                    () => first,
                    () => second,
                    () => third,
                    () => fourth,
                    () => fifth,
                    null!));

            Assert.Equal("sixth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void Create_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
            RecordType? sourceSixth)
        {
            var sourceFirst = WhiteSpaceString;
            var sourceSecond = SomeTextStructType;
            var sourceThird = PlusFifteenIdRefType;
            var sourceFourth = new { Id = One };
            var sourceFifth = decimal.MaxValue;

            var actual = Dependency<string, StructType?, RefType, object, decimal, RecordType?>.Create(
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