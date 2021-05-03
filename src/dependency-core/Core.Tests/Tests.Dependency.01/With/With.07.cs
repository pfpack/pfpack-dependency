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
        public void WithSix_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => SomeTextStructType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<RefType, long?, RecordType?, string, object, DateTime>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithSix_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType otherLast)
        {
            var sourceValue = PlusFifteenIdLowerSomeStringNameRecord;
            var source = Dependency.Create(_ => sourceValue);
            
            var otherFirst = UpperSomeString;
            var otherSecond = new object();

            var otherThird = decimal.One;
            var otherFourth = LowerSomeTextStructType;

            var otherFifth = DateTimeKind.Utc;

            var other = Dependency.Create(
                _ => otherFirst, _ => otherSecond, _ => otherThird, _ => otherFourth, _ => otherFifth, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceValue, otherFirst, otherSecond, otherThird, otherFourth, otherFifth, otherLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}