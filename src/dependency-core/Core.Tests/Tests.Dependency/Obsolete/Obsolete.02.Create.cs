using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void Obsolete_Create_02_FirstIsNull_ExpectArgumentNullException()
        {
            var second = PlusFifteenIdSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(NullStructResolver, _ => second));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void Obsolete_Create_02_SecondIsNull_ExpectArgumentNullException()
        {
            var first = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(_ => first, NullRefResolver));

            Assert.Equal("second", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void Obsolete_Create_02_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
            StructType sourceSecond)
        {
            var sourceFirst = PlusFifteenIdRefType;
            var actual = Dependency.Create(_ => sourceFirst, _ => sourceSecond);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}