using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void Create_FirstIsNull_ExpectArgumentNullException()
        {
            var second = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<StructType?, RefType?>.Create(
                    null!,
                    () => second));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void Create_SecondIsNull_ExpectArgumentNullException()
        {
            var first = UpperSomeString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<string, RefType>.Create(
                    () => first,
                    null!));

            Assert.Equal("second", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void Create_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
            RecordType? sourceSecond)
        {
            var sourceFirst = SomeTextStructType;

            var actual = Dependency<StructType, RecordType?>.Create(
                () => sourceFirst,
                () => sourceSecond);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}