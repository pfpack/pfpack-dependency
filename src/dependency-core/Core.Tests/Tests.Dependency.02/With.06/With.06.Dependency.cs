using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void WithFourDependency_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => MinusFifteen, _ => PlusFifteenIdLowerSomeStringNameRecord);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<decimal, RecordType?, StructType?, RefType>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(LowerSomeString)]
        [InlineData(SomeString)]
        public void WithFourDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            string? otherLast)
        {
            var firstSource = new object();
            var secondSource = PlusFifteenIdRefType;
            var source = Dependency.From(_ => firstSource, _ => secondSource);
            
            var otherFirst = SomeTextStructType;
            var otherSecond = ZeroIdNullNameRecord;

            var otherThird = UpperSomeString;
            var other = Dependency.From(_ => otherFirst, _ => otherSecond, _ => otherThird, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, otherFirst, otherSecond, otherThird, otherLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}