using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Fact]
        public void WithThreeResolvers_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => MinusFifteen,
                _ => ZeroIdNullNameRecord,
                _ => SomeTextStructType,
                _ => new { Id = PlusFifteen });

            var sixthValue = DateTimeKind.Utc;
            var seventhValue = PlusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<IServiceProvider, bool?>)null!,
                    _ => sixthValue,
                    _ => seventhValue));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void WithThreeResolvers_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => new object(),
                _ => MinusFifteenIdRefType,
                _ => false,
                _ => byte.MaxValue);

            var fifthValue = LowerSomeTextStructType;
            var seventhValue = PlusFifteenIdSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => fifthValue,
                    (Func<IServiceProvider, string?>)null!,
                    _ => seventhValue));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void WithThreeResolvers_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => ZeroIdRefType,
                _ => DateTimeKind.Unspecified,
                _ => decimal.MinusOne);

            var fifthValue = LowerSomeTextStructType;
            var sixthValue = UpperSomeString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => fifthValue,
                    _ => sixthValue,
                    (Func<IServiceProvider, object>)null!));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithThreeResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType? lastValue)
        {
            var firstSource = byte.MaxValue;
            var secondSource = true;

            var thirdSource = MinusOne;
            var fourthSource = DateTimeKind.Utc;

            var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource);

            var fifthValue = SomeTextStructType;
            var sixthValue = ZeroIdRefType;

            var actual = source.With(_ => fifthValue, _ => sixthValue, _ => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthValue, sixthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}