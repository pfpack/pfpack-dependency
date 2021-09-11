using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Fact]
        public void Obsolete_Create_FirstIsNull_ExpectArgumentNullException()
        {
            var second = MinusFifteenIdRefType;
            var third = PlusFifteen;
            var fourth = ZeroIdNullNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<StructType, RefType?, int, RecordType>.Create(
                    null!,
                    _ => second,
                    _ => third,
                    _ => fourth));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void Obsolete_Create_SecondIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdRefType;
            var third = SomeTextStructType;
            var fourth = PlusFifteenIdSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RefType?, string?, StructType, RecordType>.Create(
                    _ => first,
                    null!,
                    _ => third,
                    _ => fourth));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void Obsolete_Create_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = One;
            var second = ZeroIdRefType;
            var fourth = LowerSomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<int, RefType, RecordType, StructType?>.Create(
                    _ => first,
                    _ => second,
                    null!,
                    _ => fourth));

            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void Obsolete_Create_FourthIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdSomeStringNameRecord;
            var second = SomeTextStructType;
            var third = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RecordType, StructType, RefType?, int>.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    null!));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(SomeString)]
        public void Obsolete_Create_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
            string? sourceFourth)
        {
            var sourceFirst = PlusFifteenIdRefType;
            var sourceSecond = MinusFifteenIdSomeStringNameRecord;
            var sourceThird = LowerSomeTextStructType;

            var actual = Dependency<RefType?, RecordType, StructType, string?>.Create(
                _ => sourceFirst,
                _ => sourceSecond,
                _ => sourceThird,
                _ => sourceFourth);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}