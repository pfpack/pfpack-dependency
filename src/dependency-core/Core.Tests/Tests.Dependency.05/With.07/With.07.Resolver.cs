using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Fact]
        public void WithTwoResolvers_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => SomeTextStructType,
                _ => MinusFifteenIdRefType,
                _ => new[] { EmptyString },
                _ => new object(),
                _ => decimal.MaxValue);

            var seventhValue = PlusFifteenIdLowerSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<IServiceProvider, string?>)null!,
                    _ => seventhValue));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void WithTwoResolvers_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => DateTimeKind.Local,
                _ => MinusFifteenIdNullNameRecord,
                _ => LowerSomeString,
                _ => byte.MaxValue,
                _ => long.MinValue);

            var sixthValue = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => sixthValue,
                    (Func<IServiceProvider, DateTime>)null!));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void WithTwoResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            StructType lastValue)
        {
            var firstSource = decimal.MaxValue;
            var secondSource = PlusFifteenIdRefType;

            var thirdSource = new { Name = SomeString };
            var fourthSource = ZeroIdNullNameRecord;

            var fifthSource = false;

            var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource);

            var sixthValue = decimal.MinusOne;

            var actual = source.With(_ => sixthValue, _ => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthSource, sixthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}