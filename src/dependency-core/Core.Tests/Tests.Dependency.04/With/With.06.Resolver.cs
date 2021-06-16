#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Fact]
        public void WithTwoResolvers_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => ZeroIdRefType,
                _ => new object(),
                _ => long.MaxValue,
                _ => MinusFifteenIdSomeStringNameRecord);

            var sixthValue = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<IServiceProvider, RefType>)null!,
                    _ => sixthValue));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void WithTwoResolvers_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => ZeroIdNullNameRecord,
                _ => SomeTextStructType,
                _ => decimal.MinusOne,
                _ => new { Name = SomeString });

            var fifthValue = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => fifthValue,
                    (Func<IServiceProvider, DateTime?>)null!));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(MinusFifteen)]
        [InlineData(One)]
        public void WithTwoResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            int? lastValue)
        {
            var firstSource = DateTimeKind.Local;
            var secondSource = PlusFifteenIdRefType;

            var thirdSource = new { Name = UpperSomeString, Sum = decimal.One };
            var fourthSource = SomeTextStructType;

            var source = Dependency.Create(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource);

            var fifthValue = MinusFifteenIdSomeStringNameRecord;

            var actual = source.With(_ => fifthValue, _ => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}