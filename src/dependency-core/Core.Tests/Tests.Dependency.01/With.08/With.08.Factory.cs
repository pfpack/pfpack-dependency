using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void WithSevenFactories_SecondIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => MinusFifteenIdRefType);

            var thirdValue = UpperSomeString;
            var fourthValue = true;

            var fifthValue = PlusFifteenIdLowerSomeStringNameRecord;
            var sixthValue = new[] { decimal.MinusOne };

            var seventhValue = LowerSomeTextStructType;
            var restValue = DateTimeKind.Unspecified;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<object>)null!,
                    () => thirdValue,
                    () => fourthValue,
                    () => fifthValue,
                    () => sixthValue,
                    () => seventhValue,
                    () => restValue));
            
            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void WithSevenFactories_ThirdIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => WhiteSpaceString);

            var secondValue = DateTimeKind.Local;
            var fourthValue = SomeTextStructType;

            var fifthValue = default(RecordType);
            var sixthValue = PlusFifteenIdRefType;

            var seventhValue = MinusOne;
            var restValue = new { Id = PlusFifteen };

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => secondValue,
                    (Func<decimal>)null!,
                    () => fourthValue,
                    () => fifthValue,
                    () => sixthValue,
                    () => seventhValue,
                    () => restValue));
            
            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void WithSevenFactories_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => ZeroIdNullNameRecord);

            var secondValue = byte.MaxValue;
            var thirdValue = long.MinValue;

            var fifthValue = false;
            var sixthValue = WhiteSpaceString;

            var seventhValue = new object();
            var restValue = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => secondValue,
                    () => thirdValue,
                    (Func<StructType?>)null!,
                    () => fifthValue,
                    () => sixthValue,
                    () => seventhValue,
                    () => restValue));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void WithSevenFactories_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => MinusFifteenIdRefType);

            var secondValue = DateTimeKind.Unspecified;
            var thirdValue = new { Name = SomeString };

            var fourthValue = false;
            var sixthValue = MinusFifteenIdSomeStringNameRecord;

            var seventhValue = default(StructType?);
            var restValue = Enumerable.Empty<DateTimeOffset?>();

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => secondValue,
                    () => thirdValue,
                    () => fourthValue,
                    (Func<RecordType>)null!,
                    () => sixthValue,
                    () => seventhValue,
                    () => restValue));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void WithSevenFactories_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => LowerSomeTextStructType);

            var secondValue = PlusFifteenIdRefType;
            var thirdValue = PlusFifteenIdSomeStringNameRecord;

            var fourthValue = new object();
            var fifthValue = true;

            var seventhValue = DateTimeKind.Utc;
            var restValue = (long.MaxValue, long.MinValue);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => secondValue,
                    () => thirdValue,
                    () => fourthValue,
                    () => fifthValue,
                    (Func<decimal?>)null!,
                    () => seventhValue,
                    () => restValue));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void WithSevenFactories_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => EmptyString);

            var secondValue = One;
            var thirdValue = MinusFifteenIdRefType;

            var fourthValue = new[] { DateTimeKind.Local };
            var fifthValue = SomeTextStructType;

            var sixthValue = long.MinValue;
            var restValue = ZeroIdNullNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => secondValue,
                    () => thirdValue,
                    () => fourthValue,
                    () => fifthValue,
                    () => sixthValue,
                    (Func<StructType>)null!,
                    () => restValue));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Fact]
        public void WithSevenFactories_RestIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => true);

            var secondValue = new object();
            var thirdValue = decimal.MaxValue;

            var fourthValue = LowerSomeTextStructType;
            var fifthValue = PlusFifteenIdRefType;

            var sixthValue = Array.Empty<long?>();
            var seventhValue = MinusFifteenIdSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => secondValue,
                    () => thirdValue,
                    () => fourthValue,
                    () => fifthValue,
                    () => sixthValue,
                    () => seventhValue,
                    (Func<(string, int)>)null!));
            
            Assert.Equal("rest", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(int.MinValue)]
        [InlineData(PlusFifteen)]
        public void WithSevenFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            int? lastValue)
        {
            var sourceValue = SomeTextStructType;
            var source = Dependency.Create(_ => sourceValue);
            
            var secondValue = DateTimeKind.Utc;
            var thirdValue = ThreeWhiteSpacesString;

            var fourthValue = PlusFifteenIdSomeStringNameRecord;
            var fifthValue = new object();

            var sixthValue = ZeroIdRefType;
            var seventhValue = decimal.MaxValue;

            var actual = source.With(
                () => secondValue, () => thirdValue, () => fourthValue, () => fifthValue, () => sixthValue, () => seventhValue, () => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = ((sourceValue, secondValue, thirdValue, fourthValue), (fifthValue, sixthValue, seventhValue, lastValue));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}