using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithSeven_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType? lastValue)
        {
            var sourceValue = long.MinValue;
            var source = Dependency.From(_ => sourceValue);
            
            var secondValue = new object();
            var thirdValue = default(string);

            var fourthValue = PlusFifteenIdLowerSomeStringNameRecord;
            var fifthValue = byte.MaxValue;

            var sixthValue = MinusFifteen;
            var seventhValue = DateTimeKind.Unspecified;

            var actual = source.With(secondValue, thirdValue, fourthValue, fifthValue, sixthValue, seventhValue, lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = ((sourceValue, secondValue, thirdValue, fourthValue), (fifthValue, sixthValue, seventhValue, lastValue));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}