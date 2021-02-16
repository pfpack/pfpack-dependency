#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void WithTwo_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => MinusFifteenIdNullNameRecord);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<StructType, object?>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void WithTwo_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            StructType otherLast)
        {
            var sourceValue = MinusFifteenIdSomeStringNameRecord;
            var source = Dependency.Create(_ => sourceValue);

            var otherFirst = PlusFifteenIdRefType;
            var other = Dependency.Create(_ => otherFirst, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceValue, otherFirst, otherLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}