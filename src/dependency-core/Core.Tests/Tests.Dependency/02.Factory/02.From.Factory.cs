using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void From_Factory_02_FirstIsNull_ExpectArgumentNullException()
        {
            var second = PlusFifteenIdLowerSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    NullStructFactory,
                    () => second));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void From_Factory_02_SecondIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(
                    () => first,
                    NullRecordFactory));

            Assert.Equal("second", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void From_Factory_02_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
            RefType sourceSecond)
        {
            var sourceFirst = true;

            var actual = Dependency.From(
                () => sourceFirst,
                () => sourceSecond);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}