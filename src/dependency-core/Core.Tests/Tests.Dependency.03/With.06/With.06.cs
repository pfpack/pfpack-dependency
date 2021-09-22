using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(SomeString)]
        public void WithThree_ExpectResolvedValuesAreEqualToSourceAndOther(
            string? lastValue)
        {
            var firstSource = DateTimeKind.Local;
            var secondSource = MinusFifteenIdSomeStringNameRecord;

            var thirdSource = decimal.One;
            var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource);

            var fourthValue = SomeTextStructType;
            var fifthValue = PlusFifteenIdRefType;

            var actual = source.With(fourthValue, fifthValue, lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthValue, fifthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}