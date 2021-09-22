using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Fact]
        public void WithOneResolver_FourthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(
                _ => SomeTextStructType, _ => PlusFifteenIdRefType, _ => MinusFifteenIdSomeStringNameRecord);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With((Func<IServiceProvider, object>)null!));
            
            Assert.Equal("fourth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithOneResolver_FourthIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType? fourthValue)
        {
            var firstSource = SomeString;
            var secondSource = ZeroIdNullNameRecord;

            var thirdSource = LowerSomeTextStructType;
            var source = Dependency.From(_ => firstSource, _ => secondSource, _ => thirdSource);

            var actual = source.With(_ => fourthValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}