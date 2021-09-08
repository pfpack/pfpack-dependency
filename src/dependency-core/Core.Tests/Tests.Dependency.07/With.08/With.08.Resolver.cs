using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Fact]
        public void WithOneResolver_RestIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => MinusOne,
                _ => LowerSomeTextStructType,
                _ => new { Sum = decimal.One },
                _ => PlusFifteenIdRefType,
                _ => MinusFifteenIdNullNameRecord,
                _ => byte.MaxValue,
                _ => SomeString);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With((Func<IServiceProvider, DateTimeOffset?>)null!));
            
            Assert.Equal("rest", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithOneResolver_RestIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType restValue)
        {
            var firstSource = UpperSomeString;
            var secondSource = DateTimeKind.Utc;

            var thirdSource = new object();
            var fourthSource = byte.MaxValue;

            var fifthSource = ZeroIdRefType;
            var sixthSource = true;

            var seventhSource = double.MaxValue;

            var source = Dependency.Create(
                _ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource, _ => sixthSource, _ => seventhSource);

            var actual = source.With(_ => restValue);
            var actualValue = actual.Resolve();

            var expectedValue = ((firstSource, secondSource, thirdSource, fourthSource), (fifthSource, sixthSource, seventhSource, restValue));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}