using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void WithSixResolvers_SecondIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => MinusFifteenIdNullNameRecord);

            var thirdValue = PlusFifteen;
            var fourthValue = long.MaxValue;

            var fifthValue = ZeroIdRefType;
            var sixthValue = DateTimeKind.Utc;

            var lastValue = new object();

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<IServiceProvider, StructType>)null!,
                    _ => thirdValue,
                    _ => fourthValue,
                    _ => fifthValue,
                    _ => sixthValue,
                    _ => lastValue));
            
            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void WithSixResolvers_ThirdIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create<object>(_ => new());

            var secondValue = LowerSomeTextStructType;
            var fourthValue = MinusFifteenIdRefType;

            var fifthValue = PlusFifteen;
            var sixthValue = DateTimeKind.Utc;

            var lastValue = PlusFifteenIdLowerSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => secondValue,
                    (Func<IServiceProvider, long>)null!,
                    _ => fourthValue,
                    _ => fifthValue,
                    _ => sixthValue,
                    _ => lastValue));
            
            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void WithSixResolvers_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => SomeString);

            var secondValue = MinusFifteenIdRefType;
            var thirdValue = SomeTextStructType;

            var fifthValue = PlusFifteen;
            var sixthValue = byte.MaxValue;

            var lastValue = ZeroIdNullNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => secondValue,
                    _ => thirdValue,
                    (Func<IServiceProvider, DateTime>)null!,
                    _ => fifthValue,
                    _ => sixthValue,
                    _ => lastValue));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void WithSixResolvers_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => PlusFifteenIdLowerSomeStringNameRecord);

            var secondValue = long.MaxValue;
            var thirdValue = SomeTextStructType;

            var fourthValue = ZeroIdRefType;
            var sixthValue = long.MaxValue;

            var lastValue = DateTimeKind.Unspecified;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => secondValue,
                    _ => thirdValue,
                    _ => fourthValue,
                    (Func<IServiceProvider, string>)null!,
                    _ => sixthValue,
                    _ => lastValue));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void WithSixResolvers_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => decimal.MinusOne);

            var secondValue = MinusOne;
            var thirdValue = SomeTextStructType;

            var fourthValue = MinusFifteenIdSomeStringNameRecord;
            var fifthValue = false;

            var lastValue = PlusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => secondValue,
                    _ => thirdValue,
                    _ => fourthValue,
                    _ => fifthValue,
                    (Func<IServiceProvider, RefType>)null!,
                    _ => lastValue));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void WithSixResolvers_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => LowerSomeString);

            var secondValue = MinusFifteenIdRefType;
            var thirdValue = new object();

            var fourthValue = PlusFifteenIdSomeStringNameRecord;
            var fifthValue = long.MaxValue;

            var sixthValue = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => secondValue,
                    _ => thirdValue,
                    _ => fourthValue,
                    _ => fifthValue,
                    _ => sixthValue,
                    (Func<IServiceProvider, bool?>)null!));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void WithSixResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            StructType lastValue)
        {
            var sourceValue = MinusFifteenIdSomeStringNameRecord;
            var source = Dependency.Create(_ => sourceValue);
            
            var secondValue = Array.Empty<DateTime>();
            var thirdValue = PlusFifteenIdRefType;

            var fourthValue = SomeString;
            var fifthValue = PlusFifteen;

            var sixthValue = false;

            var actual = source.With(_ => secondValue, _ => thirdValue, _ => fourthValue, _ => fifthValue, _ => sixthValue, _ => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceValue, secondValue, thirdValue, fourthValue, fifthValue, sixthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}