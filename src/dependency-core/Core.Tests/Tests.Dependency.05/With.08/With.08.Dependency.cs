using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Fact]
        public void WithThreeDependency_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => ZeroIdNullNameRecord,
                _ => SomeTextStructType,
                _ => PlusFifteenIdRefType,
                _ => MinusOne,
                _ => new Tuple<string, bool, long?>(UpperSomeString, true, long.MaxValue));

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<DateTime, object?, string?>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithThreeDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType? otherLast)
        {
            var firstSource = new { Name = MixedWhiteSpacesString };
            var secondSource = Array.Empty<DateTime>();
            var thirdSource = LowerSomeString;
            var fourthSource = decimal.One;
            var fifthSource = SomeString;

            var source = Dependency.From(
                _ => firstSource,
                _ => secondSource,
                _ => thirdSource,
                _ => fourthSource,
                _ => fifthSource);

            var otherFirst = DateTimeKind.Unspecified;
            var otherSecond = PlusFifteenIdLowerSomeStringNameRecord;

            var other = Dependency.From(_ => otherFirst, _ => otherSecond, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = ((firstSource, secondSource, thirdSource, fourthSource), (fifthSource, otherFirst, otherSecond, otherLast));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}