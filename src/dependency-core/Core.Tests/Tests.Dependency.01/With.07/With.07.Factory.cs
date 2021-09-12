using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void WithSixFactories_SecondIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => long.MaxValue);

            var thirdValue = DateTimeKind.Local;
            var fourthValue = new object();

            var fifthValue = MinusFifteenIdSomeStringNameRecord;
            var sixthValue = LowerSomeTextStructType;

            var lastValue = ThreeWhiteSpacesString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<RefType?>)null!,
                    () => thirdValue,
                    () => fourthValue,
                    () => fifthValue,
                    () => sixthValue,
                    () => lastValue));
            
            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void WithSixFactories_ThirdIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => PlusFifteenIdSomeStringNameRecord);

            var secondValue = new object();
            var fourthValue = SomeTextStructType;

            var fifthValue = false;
            var sixthValue = MinusOne;

            var lastValue = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => secondValue,
                    (Func<StructType>)null!,
                    () => fourthValue,
                    () => fifthValue,
                    () => sixthValue,
                    () => lastValue));
            
            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void WithSixFactories_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => int.MaxValue);

            var secondValue = PlusFifteenIdLowerSomeStringNameRecord;
            var thirdValue = EmptyString;

            var fifthValue = SomeTextStructType;
            var sixthValue = MinusFifteenIdRefType;

            var lastValue = decimal.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => secondValue,
                    () => thirdValue,
                    (Func<object>)null!,
                    () => fifthValue,
                    () => sixthValue,
                    () => lastValue));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void WithSixFactories_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => byte.MaxValue);

            var secondValue = ZeroIdRefType;
            var thirdValue = MinusFifteenIdSomeStringNameRecord;

            var fourthValue = true;
            var sixthValue = SomeTextStructType;

            var lastValue = new object();

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => secondValue,
                    () => thirdValue,
                    () => fourthValue,
                    (Func<string?>)null!,
                    () => sixthValue,
                    () => lastValue));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void WithSixFactories_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => byte.MaxValue);

            var secondValue = PlusFifteenIdRefType;
            var thirdValue = new object();

            var fourthValue = SomeTextStructType;
            var fifthValue = DateTimeKind.Unspecified;

            var lastValue = long.MinValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => secondValue,
                    () => thirdValue,
                    () => fourthValue,
                    () => fifthValue,
                    (Func<RecordType>)null!,
                    () => lastValue));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void WithSixFactories_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => new object());

            var secondValue = LowerSomeTextStructType;
            var thirdValue = EmptyString;

            var fourthValue = MinusFifteenIdRefType;
            var fifthValue = true;

            var sixthValue = PlusFifteenIdSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => secondValue,
                    () => thirdValue,
                    () => fourthValue,
                    () => fifthValue,
                    () => sixthValue,
                    (Func<DateTime?>)null!));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithSixFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType? lastValue)
        {
            var sourceValue = int.MaxValue;
            var source = Dependency.From(_ => sourceValue);
            
            var secondValue = MinusFifteenIdSomeStringNameRecord;
            var thirdValue = UpperSomeString;

            var fourthValue = DateTimeKind.Local;
            var fifthValue = new object();

            var sixthValue = SomeTextStructType;

            var actual = source.With(() => secondValue, () => thirdValue, () => fourthValue, () => fifthValue, () => sixthValue, () => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceValue, secondValue, thirdValue, fourthValue, fifthValue, sixthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}