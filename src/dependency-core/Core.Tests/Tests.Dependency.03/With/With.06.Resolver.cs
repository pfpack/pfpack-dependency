#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Fact]
        public void WithThreeResolvers_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => SomeTextStructType, _ => false, _ => MinusFifteen);

            var fifthValue = MixedWhiteSpacesString;
            var sixthValue = PlusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<IServiceProvider, RecordType?>)null!,
                    _ => fifthValue,
                    _ => sixthValue));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void WithThreeResolvers_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => LowerSomeTextStructType, _ => byte.MaxValue, _ => PlusFifteenIdSomeStringNameRecord);

            var fourthValue = ZeroIdRefType;
            var sixthValue = DateTimeKind.Unspecified;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => fourthValue,
                    (Func<IServiceProvider, DateTimeOffset>)null!,
                    _ => sixthValue));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void WithThreeResolvers_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => UpperSomeString, _ => MinusFifteenIdRefType, _ => SomeTextStructType);

            var fourthValue = PlusFifteenIdSomeStringNameRecord;
            var fifthValue = new[] { false, true, true };

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => fourthValue,
                    _ => fifthValue,
                    (Func<IServiceProvider, long?>)null!));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void WithThreeResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            StructType lastValue)
        {
            var firstSource = ZeroIdNullNameRecord;
            var secondSource = false;

            var thirdSource = new[] { SomeString };
            var source = Dependency.Create(_ => firstSource, _ => secondSource, _ => thirdSource);

            var fourthValue = MinusFifteenIdRefType;
            var fifthValue = new object();

            var actual = source.With(_ => fourthValue, _ => fifthValue, _ => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthValue, fifthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}