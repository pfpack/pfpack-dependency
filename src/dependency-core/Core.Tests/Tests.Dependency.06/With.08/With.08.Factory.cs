using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Fact]
        public void WithTwoFactories_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => SomeTextStructType,
                _ => new { Id = One },
                _ => false,
                _ => DateTimeKind.Local,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => long.MinValue);

            var restValue = decimal.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<RefType?>)null!,
                    () => restValue));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Fact]
        public void WithTwoFactories_RestIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => DateTimeKind.Utc,
                _ => long.MinValue,
                _ => new object(),
                _ => PlusFifteenIdRefType,
                _ => TabString,
                _ => MinusOne);

            var seventhValue = MinusFifteenIdNullNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => seventhValue,
                    (Func<StructType>)null!));
            
            Assert.Equal("rest", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithTwoFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType lastValue)
        {
            var firstSource = new object();
            var secondSource = WhiteSpaceString;

            var thirdSource = LowerSomeTextStructType;
            var fourthSource = long.MinValue;

            var fifthSource = MinusFifteenIdRefType;
            var sixthSource = true;

            var source = Dependency.Create(
                _ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource, _ => sixthSource);

            var seventhValue = new[] { byte.MaxValue };

            var actual = source.With(() => seventhValue, () => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = ((firstSource, secondSource, thirdSource, fourthSource), (fifthSource, sixthSource, seventhValue, lastValue));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}