using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Fact]
        public void WithFourResolvers_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => false, _ => PlusFifteenIdRefType, _ => LowerSomeTextStructType);

            var fifthValue = decimal.One;
            var sixthValue = DateTimeKind.Unspecified;

            var seventhValue = MinusFifteenIdSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<IServiceProvider, int>)null!,
                    _ => fifthValue,
                    _ => sixthValue,
                    _ => seventhValue));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void WithFourResolvers_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => MinusOne, _ => SomeTextStructType, _ => byte.MaxValue);

            var fourthValue = bool.TrueString;
            var sixthValue = MinusFifteenIdRefType;

            var seventhValue = ZeroIdNullNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => fourthValue,
                    (Func<IServiceProvider, RefType?>)null!,
                    _ => sixthValue,
                    _ => seventhValue));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void WithFourResolvers_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => ZeroIdRefType, _ => PlusFifteenIdSomeStringNameRecord, _ => int.MinValue);

            var fourthValue = SomeTextStructType;
            var fifthValue = UpperSomeString;

            var seventhValue = decimal.MinValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => fourthValue,
                    _ => fifthValue,
                    (Func<IServiceProvider, object>)null!,
                    _ => seventhValue));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void WithFourResolvers_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => long.MaxValue, _ => MinusFifteenIdSomeStringNameRecord, _ => Array.Empty<DateTimeOffset>());

            var fourthValue = new { Id = PlusFifteen, Name = SomeString };
            var fifthValue = MinusFifteenIdRefType;

            var sixthValue = LowerSomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => fourthValue,
                    _ => fifthValue,
                    _ => sixthValue,
                    (Func<IServiceProvider, DateTime?>)null!));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(false)]
        [InlineData(true)]
        public void WithFourResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            bool? lastValue)
        {
            var firstSource = PlusFifteenIdRefType;
            var secondSource = ZeroIdNullNameRecord;

            var thirdSource = long.MinValue;
            var source = Dependency.Create(_ => firstSource, _ => secondSource, _ => thirdSource);

            var fourthValue = DateTimeKind.Local;
            var fifthValue = MinusOne;

            var sixthValue = SomeTextStructType;

            var actual = source.With(_ => fourthValue, _ => fifthValue, _ => sixthValue, _ => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthValue, fifthValue, sixthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}