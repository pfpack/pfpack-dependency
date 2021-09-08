using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Fact]
        public void WithFourFactories_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => DateTimeKind.Utc,
                _ => decimal.MaxValue,
                _ => new object(),
                _ => PlusFifteenIdLowerSomeStringNameRecord);

            var sixthValue = false;

            var seventhValue = MinusFifteenIdRefType;
            var restValue = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<int>)null!,
                    () => sixthValue,
                    () => seventhValue,
                    () => restValue));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void WithFourFactories_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => ZeroIdNullNameRecord,
                _ => byte.MaxValue,
                _ => ThreeWhiteSpacesString,
                _ => true);

            var fifthValue = PlusFifteenIdRefType;

            var seventhValue = MinusOne;
            var restValue = new { Value = decimal.MaxValue };

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => fifthValue,
                    (Func<StructType?>)null!,
                    () => seventhValue,
                    () => restValue));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void WithFourFactories_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => new[] { byte.MaxValue },
                _ => DateTimeKind.Local,
                _ => MinusFifteenIdNullNameRecord,
                _ => SomeTextStructType);

            var fifthValue = decimal.MinusOne;

            var sixthValue = WhiteSpaceString;
            var restValue = long.MinValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => fifthValue,
                    () => sixthValue,
                    (Func<RefType?>)null!,
                    () => restValue));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Fact]
        public void WithFourFactories_RestIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => byte.MaxValue,
                _ => ZeroIdRefType,
                _ => DateTimeKind.Utc,
                _ => default(string));

            var fifthValue = new object();

            var sixthValue = MinusOne;
            var seventhValue = LowerSomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => fifthValue,
                    () => sixthValue,
                    () => seventhValue,
                    (Func<RecordType>)null!));
            
            Assert.Equal("rest", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithFourFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType? lastValue)
        {
            var firstSource = new object();
            var secondSource = SomeTextStructType;

            var thirdSource = long.MinValue;
            var fourthSource = DateTimeKind.Unspecified;

            var source = Dependency.Create(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource);

            var fifthValue = PlusFifteenIdSomeStringNameRecord;

            var sixthValue = UpperSomeString;
            var seventhValue = true;

            var actual = source.With(() => fifthValue, () => sixthValue, () => seventhValue, () => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = ((firstSource, secondSource, thirdSource, fourthSource), (fifthValue, sixthValue, seventhValue, lastValue));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}