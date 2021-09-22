using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void WithFiveResolvers_ThirdIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => SomeTextStructType, _ => PlusFifteenIdRefType);

            var fourthValue = true;
            var fifthValue = decimal.MinValue;

            var sixthValue = new object();
            var lastValue = DateTimeKind.Unspecified;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<IServiceProvider, RecordType?>)null!,
                    _ => fourthValue,
                    _ => fifthValue,
                    _ => sixthValue,
                    _ => lastValue));
            
            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void WithFiveResolvers_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => MinusOne, _ => ZeroIdNullNameRecord);

            var thirdValue = LowerSomeTextStructType;
            var fifthValue = WhiteSpaceString;

            var sixthValue = MinusFifteenIdSomeStringNameRecord;
            var lastValue = true;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => thirdValue,
                    (Func<IServiceProvider, long>)null!,
                    _ => fifthValue,
                    _ => sixthValue,
                    _ => lastValue));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void WithFiveResolvers_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => MinusFifteenIdRefType, _ => Zero);

            var thirdValue = PlusFifteenIdSomeStringNameRecord;
            var fourthValue = SomeTextStructType;

            var sixthValue = UpperSomeString;
            var lastValue = DateTimeKind.Utc;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => thirdValue,
                    _ => fourthValue,
                    (Func<IServiceProvider, DateTime?>)null!,
                    _ => sixthValue,
                    _ => lastValue));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void WithFiveResolvers_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => MinusOne, _ => PlusFifteenIdSomeStringNameRecord);

            var thirdValue = long.MinValue;
            var fourthValue = new object();

            var fifthValue = LowerSomeTextStructType;
            var lastValue = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => thirdValue,
                    _ => fourthValue,
                    _ => fifthValue,
                    (Func<IServiceProvider, RefType>)null!,
                    _ => lastValue));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void WithFiveResolvers_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => false, _ => SomeTextStructType);

            var thirdValue = byte.MaxValue;
            var fourthValue = LowerSomeString;

            var fifthValue = MinusFifteenIdSomeStringNameRecord;
            var sixthValue = PlusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => thirdValue,
                    _ => fourthValue,
                    _ => fifthValue,
                    _ => sixthValue,
                    (Func<IServiceProvider, int>)null!));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithFiveResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType? lastValue)
        {
            var firstSource = MinusOne;
            var secondSource = SomeTextStructType;

            var source = Dependency.From(_ => firstSource, _ => secondSource);

            var thirdValue = new object();
            var fourthValue = DateTimeKind.Local;

            var fifthValue = ZeroIdNullNameRecord;
            var sixthValue = int.MaxValue;

            var actual = source.With(_ => thirdValue, _ => fourthValue, _ => fifthValue, _ => sixthValue, _ => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdValue, fourthValue, fifthValue, sixthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}