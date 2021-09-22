using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(UpperSomeString)]
        public void Of_06_ExpectResolvedValuesAreEqualToSource(
            string? sourceSixth)
        {
            var sourceFirst = SomeTextStructType;
            var sourceSecond = DateTimeKind.Unspecified;
            var sourceThird = PlusFifteenIdRefType;
            var sourceFourth = ZeroIdNullNameRecord;
            var sourceFifth = new { Id = One, Value = decimal.MaxValue };

            var actual = Dependency.Of(
                sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth, sourceSixth);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth, sourceSixth);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}