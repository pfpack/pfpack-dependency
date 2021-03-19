#nullable enable

using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Fact]
        public void WithTwo_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => decimal.MaxValue,
                _ => new object(),
                _ => LowerSomeTextStructType,
                _ => DateTimeKind.Local,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => ZeroIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<long, string?>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(false)]
        [InlineData(true)]
        public void WithTwo_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            bool? otherLast)
        {
            var firstSource = new { Id = PlusFifteen };
            var secondSource = new[] { MinusFifteen, One, int.MaxValue };
            var thirdSource = decimal.MinusOne;
            var fourthSource = LowerSomeString;
            var fifthSource = ZeroIdNullNameRecord;
            var sixthSource = SomeTextStructType;

            var source = Dependency.Create(
                _ => firstSource,
                _ => secondSource,
                _ => thirdSource,
                _ => fourthSource,
                _ => fifthSource,
                _ => sixthSource);
            
            var otherFirst = PlusFifteenIdRefType;
            var other = Dependency.Create(_ => otherFirst, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = ((firstSource, secondSource, thirdSource, fourthSource), (fifthSource, sixthSource, otherFirst, otherLast));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}