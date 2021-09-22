using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void From_Resolver_02_FirstIsNull_ExpectArgumentNullException()
        {
            var second = PlusFifteenIdSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(NullStructResolver, _ => second));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void From_Resolver_02_SecondIsNull_ExpectArgumentNullException()
        {
            var first = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.From(_ => first, NullRefResolver));

            Assert.Equal("second", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void From_Resolver_02_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
            StructType sourceSecond)
        {
            var sourceFirst = PlusFifteenIdRefType;
            var actual = Dependency.From(_ => sourceFirst, _ => sourceSecond);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}