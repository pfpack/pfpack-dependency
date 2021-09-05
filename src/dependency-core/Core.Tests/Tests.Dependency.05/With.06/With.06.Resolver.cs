using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Fact]
        public void WithOneResolver_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => MinusFifteen,
                _ => SomeTextStructType,
                _ => PlusFifteenIdRefType,
                _ => true,
                _ => MinusFifteenIdSomeStringNameRecord);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With((Func<IServiceProvider, long>)null!));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithOneResolver_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType? sixthValue)
        {
            var firstSource = long.MinValue;
            var secondSource = LowerSomeTextStructType;

            var thirdSource = byte.MaxValue;
            var fourthSource = new[] { EmptyString, MixedWhiteSpacesString, TabString };

            var fifthSource = PlusFifteenIdRefType;

            var source = Dependency.Create(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource, _ => fifthSource);

            var actual = source.With(_ => sixthValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthSource, sixthValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}