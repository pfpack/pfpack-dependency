using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithTwo_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType? lastValue)
        {
            var firstSource = MinusFifteenIdSomeStringNameRecord;
            var secondSource = decimal.MinusOne;

            var thirdSource = Array.Empty<string>();
            var fourthSource = new object();

            var fifthSource = byte.MaxValue;

            var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource);

            var sixthValue = LowerSomeTextStructType;

            var actual = source.With(sixthValue, lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthSource, sixthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}