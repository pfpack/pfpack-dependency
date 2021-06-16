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
        public void WithOneResolver_FifthIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => SomeTextStructType,
                _ => ZeroIdNullNameRecord,
                _ => LowerSomeString,
                _ => PlusFifteenIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With((Func<IServiceProvider, DateTimeOffset>)null!));
            
            Assert.Equal("fifth", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithOneResolver_FifthIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType fifthValue)
        {
            var firstSource = LowerSomeTextStructType;
            var secondSource = false;

            var thirdSource = MinusFifteenIdNullNameRecord;
            var fourthSource = byte.MaxValue;

            var source = Dependency.Create(_ => firstSource, _ => secondSource, _ => thirdSource, _ => fourthSource);

            var actual = source.With(_ => fifthValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, fourthSource, fifthValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}