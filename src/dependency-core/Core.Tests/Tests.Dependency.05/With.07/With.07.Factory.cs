using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Fact]
        public void WithTwoFactories_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => WhiteSpaceString,
                _ => One,
                _ => MinusFifteenIdRefType,
                _ => long.MinValue,
                _ => ZeroIdNullNameRecord);

            var seventhValue = new object();

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<StructType?>)null!,
                    () => seventhValue));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void WithTwoFactories_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => byte.MaxValue,
                _ => true,
                _ => LowerSomeTextStructType,
                _ => new object(),
                _ => decimal.MinusOne);

            var sixthValue = MinusFifteenIdNullNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => sixthValue,
                    (Func<RefType>)null!));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithTwoFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType? lastValue)
        {
            var firstSource = DateTimeKind.Unspecified;
            var secondSource = WhiteSpaceString;

            var thirdSource = long.MinValue;
            var fourthSource = new { Value = decimal.One };

            var fifthSource = SomeTextStructType;

            var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource);

            var sixthValue = PlusFifteenIdRefType;

            var actual = source.With(() => sixthValue, () => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthSource, sixthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}