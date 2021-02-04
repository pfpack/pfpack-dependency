#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void WithOne_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => MinusFifteen, _ => SomeTextStructType);
            var other = null as Dependency<RefType>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(other!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithOne_OtherIsNotNull_ExpectResolvedValuesAreSameAsSourceAndOther(
            RecordType? otherValue)
        {
            var firstSource = ZeroIdRefType;
            var secondSource = SomeTextStructType;

            var source = Dependency.Create(_ => firstSource, _ => secondSource);
            var other = Dependency.Create(_ => otherValue);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, otherValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}