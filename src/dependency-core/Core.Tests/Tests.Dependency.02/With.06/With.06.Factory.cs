using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void WithFourFactories_ThirdIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => SomeTextStructType, _ => decimal.One);

            var fourthValue = DateTimeKind.Local;
            var fifthValue = ZeroIdNullNameRecord;

            var lastValue = byte.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<RefType?>)null!,
                    () => fourthValue,
                    () => fifthValue,
                    () => lastValue));
            
            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void WithFourFactories_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => PlusFifteenIdSomeStringNameRecord, _ => One);

            var thirdValue = LowerSomeTextStructType;
            var fifthValue = new object();

            var lastValue = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => thirdValue,
                    (Func<int?>)null!,
                    () => fifthValue,
                    () => lastValue));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void WithFourFactories_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => false, _ => SomeTextStructType);

            var thirdValue = ZeroIdRefType;
            var fourthValue = ThreeWhiteSpacesString;

            var lastValue = decimal.MinValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => thirdValue,
                    () => fourthValue,
                    (Func<RecordType>)null!,
                    () => lastValue));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void WithFourFactories_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => TabString, _ => decimal.One);

            var thirdValue = ulong.MaxValue;
            var fourthValue = MinusFifteenIdRefType;

            var fifthValue = PlusFifteenIdLowerSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => thirdValue,
                    () => fourthValue,
                    () => fifthValue,
                    (Func<StructType>)null!));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithFourFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType lastValue)
        {
            var firstSource = true;
            var secondSource = DateTimeKind.Utc;

            var source = Dependency.From(_ => firstSource, _ => secondSource);

            var thirdValue = SomeTextStructType;
            var fourthValue = new object();

            var fifthValue = MinusFifteenIdSomeStringNameRecord;

            var actual = source.With(() => thirdValue, () => fourthValue, () => fifthValue, () => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdValue, fourthValue, fifthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}