using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void From_Resolver_04_FirstIsNull_ExpectArgumentNullException()
        {
            var second = ZeroIdRefType;
            var third = MinusFifteenIdSomeStringNameRecord;
            var fourth = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(NullRefResolver, _ => second, _ => third, _ => fourth));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void From_Resolver_04_SecondIsNull_ExpectArgumentNullException()
        {
            var first = SomeTextStructType;
            var third = PlusFifteenIdLowerSomeStringNameRecord;
            var fourth = new object();

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(_ => first, NullRecordResolver, _ => third, _ => fourth));

            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void From_Resolver_04_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = PlusFifteenIdRefType;
            var second = int.MaxValue;
            var fourth = LowerSomeString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(_ => first, _ => second, NullStructResolver, _ => fourth));

            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void From_Resolver_04_FourthIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteen;
            var second = SomeTextStructType;
            var third = LowerSomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(_ => first, _ => second, _ => third, NullRefResolver));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void From_Resolver_04_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
            StructType sourceFourth)
        {
            var sourceFirst = Zero;
            var sourceSecond = PlusFifteenIdLowerSomeStringNameRecord;
            var sourceThird = new object();

            var actual = Dependency.From(_ => sourceFirst, _ => sourceSecond, _ => sourceThird, _ => sourceFourth);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}