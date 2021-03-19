#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Fact]
        public void WithOne_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => new { Name = SomeString },
                _ => MinusFifteen,
                _ => ZeroIdRefType,
                _ => SomeTextStructType,
                _ => PlusFifteenIdSomeStringNameRecord,
                _ => true,
                _ => MinusFifteenIdNullNameRecord);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<DateTimeOffset>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithOne_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType? otherValue)
        {
            var firstSource = ZeroIdRefType;
            var secondSource = UpperSomeString;
            var thirdSource = PlusFifteen;
            var fourthSource = PlusFifteenIdSomeStringNameRecord;
            var fifthSource = byte.MaxValue;
            var sixthSource = new Tuple<int?, string?, decimal>(One, MixedWhiteSpacesString, decimal.MaxValue);
            var seventhSource = long.MinValue;

            var source = Dependency.Create(
                _ => firstSource,
                _ => secondSource,
                _ => thirdSource,
                _ => fourthSource,
                _ => fifthSource,
                _ => sixthSource,
                _ => seventhSource);
                
            var other = Dependency.Create(_ => otherValue);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = ((firstSource, secondSource, thirdSource, fourthSource), (fifthSource, sixthSource, seventhSource, otherValue));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}