using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void WithThreeFactories_SecondIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => MinusFifteenIdNullNameRecord);

            var thirdValue = LowerSomeTextStructType;
            var lastValue = decimal.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<RefType>)null!,
                    () => thirdValue,
                    () => lastValue));
            
            Assert.Equal("second", ex.ParamName);
        }

        [Fact]
        public void WithThreeFactories_ThirdIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => MinusFifteenIdRefType);

            var secondValue = SomeTextStructType;
            var lastValue = PlusFifteenIdLowerSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => secondValue,
                    (Func<long>)null!,
                    () => lastValue));
            
            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void WithThreeFactories_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => ZeroIdNullNameRecord);

            var secondValue = SomeTextStructType;
            var thirdValue = PlusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => secondValue,
                    () => thirdValue,
                    (Func<object?>)null!));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void WithThreeFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            StructType lastValue)
        {
            var sourceValue = PlusFifteenIdRefType;
            var source = Dependency.From(_ => sourceValue);
            
            var secondValue = long.MaxValue;
            var thirdValue = MinusFifteenIdSomeStringNameRecord;

            var actual = source.With(() => secondValue, () => thirdValue, () => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceValue, secondValue, thirdValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}