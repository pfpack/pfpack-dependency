using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void WithSevenResolvers_SecondIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => SomeTextStructType);

            var thirdValue = EmptyString;
            var fourthValue = MinusFifteenIdRefType;

            var fifthValue = PlusFifteen;
            var sixthValue = DateTimeKind.Utc;

            var seventhValue = MinusFifteenIdSomeStringNameRecord;
            var restValue = decimal.MinusOne;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<IServiceProvider, byte?>)null!,
                    _ => thirdValue,
                    _ => fourthValue,
                    _ => fifthValue,
                    _ => sixthValue,
                    _ => seventhValue,
                    _ => restValue));
            
            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void WithSevenResolvers_ThirdIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => SomeTextStructType);

            var secondValue = Array.Empty<byte>();
            var fourthValue = MinusFifteenIdRefType;

            var fifthValue = PlusFifteen;
            var sixthValue = DateTimeKind.Utc;

            var seventhValue = MinusFifteenIdSomeStringNameRecord;
            var restValue = decimal.MinusOne;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => secondValue,
                    (Func<IServiceProvider, StructType>)null!,
                    _ => fourthValue,
                    _ => fifthValue,
                    _ => sixthValue,
                    _ => seventhValue,
                    _ => restValue));
            
            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void WithSevenResolvers_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => MinusFifteenIdRefType);

            var secondValue = MixedWhiteSpacesString;
            var thirdValue = MinusFifteenIdRefType;

            var fifthValue = PlusFifteen;
            var sixthValue = byte.MaxValue;

            var seventhValue = MinusFifteenIdSomeStringNameRecord;
            var restValue = LowerSomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => secondValue,
                    _ => thirdValue,
                    (Func<IServiceProvider, RecordType[]>)null!,
                    _ => fifthValue,
                    _ => sixthValue,
                    _ => seventhValue,
                    _ => restValue));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void WithSevenResolvers_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => decimal.MaxValue);

            var secondValue = long.MaxValue;
            var thirdValue = SomeTextStructType;

            var fourthValue = MinusFifteenIdSomeStringNameRecord;
            var sixthValue = new object();

            var seventhValue = PlusFifteenIdRefType;
            var restValue = DateTimeKind.Unspecified;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => secondValue,
                    _ => thirdValue,
                    _ => fourthValue,
                    (Func<IServiceProvider, DateTimeOffset?>)null!,
                    _ => sixthValue,
                    _ => seventhValue,
                    _ => restValue));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void WithSevenResolvers_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => decimal.MinusOne);

            var secondValue = MinusOne;
            var thirdValue = SomeTextStructType;

            var fourthValue = MinusFifteenIdSomeStringNameRecord;
            var fifthValue = new[] { TwoWhiteSpacesString };

            var seventhValue = PlusFifteenIdRefType;
            var restValue = DateTimeKind.Unspecified;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => secondValue,
                    _ => thirdValue,
                    _ => fourthValue,
                    _ => fifthValue,
                    (Func<IServiceProvider, object?>)null!,
                    _ => seventhValue,
                    _ => restValue));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void WithSevenResolvers_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => MinusFifteenIdSomeStringNameRecord);

            var secondValue = UpperSomeString;
            var thirdValue = int.MaxValue;

            var fourthValue = DateTimeKind.Utc;
            var fifthValue = MinusFifteenIdNullNameRecord;

            var sixthValue = ZeroIdRefType;
            var restValue = decimal.One;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => secondValue,
                    _ => thirdValue,
                    _ => fourthValue,
                    _ => fifthValue,
                    _ => sixthValue,
                    (Func<IServiceProvider, RecordType>)null!,
                    _ => restValue));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Fact]
        public void WithSevenResolvers_RestIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => MinusFifteenIdSomeStringNameRecord);

            var secondValue = SomeTextStructType;
            var thirdValue = PlusFifteen;

            var fourthValue = MinusFifteenIdRefType;
            var fifthValue = decimal.MaxValue;

            var sixthValue = true;
            var seventhValue = new { Text = SomeString };

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => secondValue,
                    _ => thirdValue,
                    _ => fourthValue,
                    _ => fifthValue,
                    _ => sixthValue,
                    _ => seventhValue,
                    (Func<IServiceProvider, RefType?>)null!));
            
            Assert.Equal("rest", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithSevenResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType lastValue)
        {
            var sourceValue = new { Value = MinusFifteen };
            var source = Dependency.From(_ => sourceValue);
            
            var secondValue = new[] { Zero, int.MinValue, int.MaxValue };
            var thirdValue = new object();

            var fourthValue = SomeTextStructType;
            var fifthValue = MinusFifteenIdNullNameRecord;

            var sixthValue = byte.MaxValue;
            var seventhValue = LowerSomeString;

            var actual = source.With(
                _ => secondValue, _ => thirdValue, _ => fourthValue, _ => fifthValue, _ => sixthValue, _ => seventhValue, _ => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = ((sourceValue, secondValue, thirdValue, fourthValue), (fifthValue, sixthValue, seventhValue, lastValue));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}