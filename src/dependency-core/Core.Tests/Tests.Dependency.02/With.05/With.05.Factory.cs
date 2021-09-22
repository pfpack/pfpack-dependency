using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void WithThreeFactories_ThirdIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => long.MaxValue, _ => PlusFifteenIdLowerSomeStringNameRecord);

            var fourthValue = LowerSomeTextStructType;
            var lastValue = byte.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<RefType?>)null!,
                    () => fourthValue,
                    () => lastValue));
            
            Assert.Equal("third", ex.ParamName);
        }

        [Fact]
        public void WithThreeFactories_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => MinusFifteenIdRefType, _ => false);

            var thirdValue = ZeroIdNullNameRecord;
            var lastValue = LowerSomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => thirdValue,
                    (Func<long>)null!,
                    () => lastValue));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Fact]
        public void WithThreeFactories_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => new object(), _ => decimal.One);

            var thirdValue = SomeTextStructType;
            var fourthValue = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => thirdValue,
                    () => fourthValue,
                    (Func<RecordType>)null!));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void WithThreeFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            StructType lastValue)
        {
            var firstSource = MinusFifteenIdSomeStringNameRecord;
            var secondSource = true;

            var source = Dependency.From(_ => firstSource, _ => secondSource);

            var thirdValue = WhiteSpaceString;
            var fourthValue = PlusFifteenIdRefType;

            var actual = source.With(() => thirdValue, () => fourthValue, () => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdValue, fourthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}