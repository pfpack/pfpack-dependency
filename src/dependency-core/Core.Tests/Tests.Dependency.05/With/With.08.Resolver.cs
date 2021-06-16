#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Fact]
        public void WithThreeResolvers_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => UpperSomeString,
                _ => Zero,
                _ => LowerSomeTextStructType,
                _ => new { Id = One });

            var seventhValue = byte.MaxValue;
            var restValue = ZeroIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<IServiceProvider, string?>)null!,
                    _ => seventhValue,
                    _ => restValue));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void WithThreeResolvers_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => new object(),
                _ => SomeTextStructType,
                _ => false,
                _ => long.MaxValue,
                _ => MinusFifteenIdSomeStringNameRecord);

            var sixthValue = PlusFifteenIdRefType;
            var restValue = byte.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => sixthValue,
                    (Func<IServiceProvider, StructType>)null!,
                    _ => restValue));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Fact]
        public void WithThreeResolvers_RestIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => SomeTextStructType,
                _ => DateTimeKind.Unspecified,
                _ => decimal.MinusOne,
                _ => new object(),
                _ => PlusFifteenIdLowerSomeStringNameRecord);

            var sixthValue = MinusFifteenIdRefType;
            var seventhValue = EmptyString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => sixthValue,
                    _ => seventhValue,
                    (Func<IServiceProvider, DateTimeOffset?>)null!));
            
            Assert.Equal("rest", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithThreeResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType? lastValue)
        {
            var firstSource = true;
            var secondSource = new[] { MixedWhiteSpacesString, null, SomeString };

            var thirdSource = SomeTextStructType;
            var fourthSource = new object();

            var fifthSource = DateTimeKind.Utc;

            var source = Dependency.Create(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource);

            var sixthValue = MinusFifteenIdSomeStringNameRecord;
            var seventhValue = byte.MaxValue;

            var actual = source.With(_ => sixthValue, _ => seventhValue, _ => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = ((firstSource, secondSource, thirdSource, fourthSource), (fifthSource, sixthValue, seventhValue, lastValue));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}