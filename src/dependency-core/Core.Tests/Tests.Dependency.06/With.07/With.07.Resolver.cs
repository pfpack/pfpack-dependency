using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Fact]
        public void WithOneResolver_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => PlusFifteenIdRefType,
                _ => MixedWhiteSpacesString,
                _ => SomeTextStructType,
                _ => PlusFifteenIdSomeStringNameRecord,
                _ => byte.MaxValue,
                _ => false);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With((Func<IServiceProvider, object?>)null!));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void WithOneResolver_SeventhIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            StructType seventhValue)
        {
            var firstSource = MinusFifteenIdRefType;
            var secondSource = decimal.MinusOne;

            var thirdSource = DateTimeKind.Unspecified;
            var fourthSource = new object();

            var fifthSource = ZeroIdNullNameRecord;
            var sixthSource = Array.Empty<DateTime>();

            var source = Dependency.From(
                _ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource, _ => sixthSource);

            var actual = source.With(_ => seventhValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthSource, sixthSource, seventhValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}