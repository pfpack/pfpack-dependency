using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Fact]
        public void WithFourResolvers_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => LowerSomeString,
                _ => PlusFifteenIdRefType,
                _ => MinusFifteenIdNullNameRecord,
                _ => decimal.MaxValue);

            var sixthValue = SomeTextStructType;

            var seventhValue = new object();
            var restValue = PlusFifteen;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<IServiceProvider, RecordType>)null!,
                    _ => sixthValue,
                    _ => seventhValue,
                    _ => restValue));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void WithFourResolvers_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => ZeroIdNullNameRecord,
                _ => MinusFifteenIdRefType,
                _ => new[] { EmptyString, UpperSomeString, SomeString },
                _ => new { Name = SomeString });

            var fifthValue = byte.MaxValue;

            var seventhValue = DateTimeKind.Utc;
            var restValue = LowerSomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => fifthValue,
                    (Func<IServiceProvider, DateTime?>)null!,
                    _ => seventhValue,
                    _ => restValue));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Fact]
        public void WithFourResolvers_SeventhIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => decimal.MaxValue,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => SomeTextStructType,
                _ => false);

            var fifthValue = UpperSomeString;

            var sixthValue = long.MinValue;
            var restValue = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => fifthValue,
                    _ => sixthValue,
                    (Func<IServiceProvider, StructType>)null!,
                    _ => restValue));
            
            Assert.Equal("seventh", ex.ParamName);
        }

        [Fact]
        public void WithFourResolvers_RestIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => LowerSomeTextStructType,
                _ => Zero,
                _ => SomeString);

            var fifthValue = byte.MaxValue;

            var sixthValue = decimal.One;
            var seventhValue = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    _ => fifthValue,
                    _ => sixthValue,
                    _ => seventhValue,
                    (Func<IServiceProvider, StructType?>)null!));
            
            Assert.Equal("rest", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void WithFourResolvers_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            StructType lastValue)
        {
            var firstSource = DateTimeKind.Local;
            var secondSource = new { Value = decimal.MinValue };

            var thirdSource = MinusFifteenIdRefType;
            var fourthSource = UpperSomeString;

            var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource);

            var fifthValue = true;

            var sixthValue = long.MaxValue;
            var seventhValue = ZeroIdNullNameRecord;

            var actual = source.With(_ => fifthValue, _ => sixthValue, _ => seventhValue, _ => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = ((firstSource, secondSource, thirdSource, fourthSource), (fifthValue, sixthValue, seventhValue, lastValue));
            Assert.Equal(expectedValue, actualValue);
        }
    }
}