using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Fact]
        public void WithThreeFactories_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => SomeTextStructType,
                _ => new object(),
                _ => DateTimeKind.Utc,
                _ => true);

            var sixthValue = MinusFifteenIdSomeStringNameRecord;
            var seventhValue = decimal.One;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<RefType>)null!,
                    () => sixthValue,
                    () => seventhValue));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void WithThreeFactories_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => new object(),
                _ => UpperSomeString,
                _ => MinusFifteenIdRefType,
                _ => ZeroIdNullNameRecord);

            var fifthValue = decimal.MaxValue;
            var seventhValue = new[] { false, true };

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => fifthValue,
                    (Func<StructType>)null!,
                    () => seventhValue));

            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void WithThreeFactories_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => long.MinValue,
                _ => SomeTextStructType,
                _ => WhiteSpaceString,
                _ => byte.MaxValue);

            var fifthValue = PlusFifteenIdRefType;
            var sixthValue = new object();

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => fifthValue,
                    () => sixthValue,
                    (Func<RecordType?>)null!));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(false)]
        [InlineData(true)]
        public void WithThreeFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            bool? lastValue)
        {
            var firstSource = PlusFifteenIdRefType;
            var secondSource = long.MaxValue;

            var thirdSource = SomeTextStructType;
            var fourthSource = new object();

            var source = Dependency.Create(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource);

            var fifthValue = decimal.MinusOne;
            var sixthValue = MinusFifteenIdSomeStringNameRecord;

            var actual = source.With(() => fifthValue, () => sixthValue, () => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthValue, sixthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}