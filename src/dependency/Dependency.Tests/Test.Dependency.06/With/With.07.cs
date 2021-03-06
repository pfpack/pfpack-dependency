#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Fact]
        public void WithOne_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdRefType,
                _ => LowerSomeTextStructType,
                _ => PlusFifteen,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => DateTimeKind.Local,
                _ => ThreeWhiteSpacesString);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<DateTimeOffset>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithOne_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType? otherValue)
        {
            var firstSource = MinusFifteen;
            var secondSource = PlusFifteenIdSomeStringNameRecord;
            var thirdSource = SomeTextStructType;
            var fourthSource = DateTimeKind.Unspecified;
            var fifthSource = decimal.One;
            var sixthSource = new object();

            var source = Dependency.Create(
                _ => firstSource,
                _ => secondSource,
                _ => thirdSource,
                _ => fourthSource,
                _ => fifthSource,
                _ => sixthSource);
                
            var other = Dependency.Create(_ => otherValue);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthSource, sixthSource, otherValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}