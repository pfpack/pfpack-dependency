using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Fact]
        public void WithOneFactory_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => SomeTextStructType,
                _ => MinusOne,
                _ => new object(),
                _ => ZeroIdRefType,
                _ => true,
                _ => PlusFifteenIdSomeStringNameRecord);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With((Func<long>)null!));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithOneFactory_SeventhIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType? seventhValue)
        {
            var firstSource = new[] { MinusOne, Zero, One };
            var secondSource = UpperSomeString;

            var thirdSource = false;
            var fourthSource = LowerSomeTextStructType;

            var fifthSource = decimal.MaxValue;
            var sixthSource = MinusFifteenIdSomeStringNameRecord;

            var source = Dependency.From(
                _ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource, _ => sixthSource);

            var actual = source.With(() => seventhValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthSource, sixthSource, seventhValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}