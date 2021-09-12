using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Fact]
        public void WithFiveResolvers_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => SomeTextStructType, _ => MinusFifteenIdSomeStringNameRecord, _ => Zero);

            var fifthValue = MinusFifteenIdRefType;
            var sixthValue = DateTimeKind.Local;

            var seventhValue = true;
            var restValue = decimal.MinValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<IServiceProvider, object?>)null!,
                    _ => fifthValue,
                    _ => sixthValue,
                    _ => seventhValue,
                    _ => restValue));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void WithFiveResolvers_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => ZeroIdRefType, _ => decimal.One, _ => PlusFifteen);

            var fourthValue = DateTimeKind.Unspecified;
            var sixthValue = MinusFifteenIdSomeStringNameRecord;

            var seventhValue = LowerSomeTextStructType;
            var restValue = false;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => fourthValue,
                    (Func<IServiceProvider, string?[]?>)null!,
                    _ => sixthValue,
                    _ => seventhValue,
                    _ => restValue));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void WithFiveResolvers_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => MinusFifteenIdSomeStringNameRecord, _ => SomeTextStructType, _ => PlusFifteenIdRefType);

            var fourthValue = DateTimeKind.Utc;
            var fifthValue = new object();

            var seventhValue = int.MaxValue;
            var restValue = byte.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => fourthValue,
                    _ => fifthValue,
                    (Func<IServiceProvider, RefType>)null!,
                    _ => seventhValue,
                    _ => restValue));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void WithFiveResolvers_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => false, _ => MixedWhiteSpacesString, _ => DateTimeKind.Unspecified);

            var fourthValue = MinusFifteenIdRefType;
            var fifthValue = decimal.MinValue;

            var sixthValue = ZeroIdNullNameRecord;
            var restValue = Unit.Value;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => fourthValue,
                    _ => fifthValue,
                    _ => sixthValue,
                    (Func<IServiceProvider, StructType?>)null!,
                    _ => restValue));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Fact]
        public void WithFiveResolvers_RestIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => LowerSomeTextStructType, _ => MinusFifteenIdRefType, _ => decimal.One);

            var fourthValue = true;
            var fifthValue = DateTimeKind.Utc;

            var sixthValue = new[] { EmptyString, SomeString, UpperSomeString };
            var seventhValue = MinusFifteenIdSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => fourthValue,
                    _ => fifthValue,
                    _ => sixthValue,
                    _ => seventhValue,
                    (Func<IServiceProvider, RecordType?>)null!));
            
            Assert.Equal("rest", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithFiveResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType lastValue)
        {
            var firstSource = byte.MaxValue;
            var secondSource = MinusFifteenIdSomeStringNameRecord;

            var thirdSource = SomeString;
            var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource);

            var fourthValue = true;
            var fifthValue = LowerSomeTextStructType;

            var sixthValue = new { Text = SomeString };
            var seventhValue = decimal.MinValue;

            var actual = source.With(_ => fourthValue, _ => fifthValue, _ => sixthValue, _ => seventhValue, _ => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = ((firstSource, secondSource, thirdSource, fourthValue), (fifthValue, sixthValue, seventhValue, lastValue));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}