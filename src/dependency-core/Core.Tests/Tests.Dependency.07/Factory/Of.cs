using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void Of_ExpectResolvedValuesAreEqualToSource(
            RefType? sourceSeventh)
        {
            var sourceFirst = decimal.One;
            var sourceSecond = new object();
            var sourceThird = long.MaxValue;
            var sourceFourth = SomeTextStructType;
            var sourceFifth = MinusFifteenIdSomeStringNameRecord;
            var sourceSixth = DateTimeKind.Local;

            var actual = Dependency<decimal, object?, long?, StructType?, RecordType, DateTimeKind, RefType?>.Of(
                sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth, sourceSixth, sourceSeventh);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth, sourceSixth, sourceSeventh);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}