using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void From_Factory_FirstIsNull_ExpectArgumentNullException()
        {
            var second = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<StructType?, RefType?>.From(
                    null!,
                    () => second));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void From_Factory_SecondIsNull_ExpectArgumentNullException()
        {
            var first = UpperSomeString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<string, RefType>.From(
                    () => first,
                    null!));

            Assert.Equal("second", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void From_Factory_FactoriesAreNotNull_ExpectResolvedValuesAreEqualToSource(
            RecordType? sourceSecond)
        {
            var sourceFirst = SomeTextStructType;

            var actual = Dependency<StructType, RecordType?>.From(
                () => sourceFirst,
                () => sourceSecond);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}