using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Fact]
        public void WithTwoFactories_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => DateTimeKind.Utc,
                _ => PlusFifteenIdSomeStringNameRecord,
                _ => false,
                _ => MinusFifteenIdRefType);

            var sixthValue = long.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    (Func<StructType>)null!,
                    () => sixthValue));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Fact]
        public void WithTwoFactories_SixthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => decimal.MinValue,
                _ => new object(),
                _ => LowerSomeTextStructType,
                _ => PlusFifteenIdRefType);

            var fifthValue = TabString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(
                    () => fifthValue,
                    (Func<RecordType>)null!));
            
            Assert.Equal("sixth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithTwoFactories_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType lastValue)
        {
            var firstSource = byte.MaxValue;
            var secondSource = SomeTextStructType;

            var thirdSource = Array.Empty<string>();
            var fourthSource = ZeroIdNullNameRecord;

            var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource);

            var fifthValue = decimal.One;

            var actual = source.With(() => fifthValue, () => lastValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthValue, lastValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}