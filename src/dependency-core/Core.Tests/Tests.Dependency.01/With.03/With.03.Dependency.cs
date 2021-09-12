using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void WithTwoDependency_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => MinusFifteenIdNullNameRecord);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<StructType, object?>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void WithTwoDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            StructType otherLast)
        {
            var sourceValue = MinusFifteenIdSomeStringNameRecord;
            var source = Dependency.From(_ => sourceValue);

            var otherFirst = PlusFifteenIdRefType;
            var other = Dependency.From(_ => otherFirst, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceValue, otherFirst, otherLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}