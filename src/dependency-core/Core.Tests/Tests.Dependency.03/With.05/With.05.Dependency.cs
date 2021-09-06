using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Fact]
        public void WithTwoDependency_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => int.MinValue, _ => MinusFifteenIdRefType, _ => new object());

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<string, StructType>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithTwoDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType? otherLast)
        {
            var firstSource = NullTextStructType;
            var secondSource = PlusFifteenIdRefType;

            var thirdSource = int.MinValue;
            var source = Dependency.Create(_ => firstSource, _ => secondSource, _ => thirdSource);

            var otherFirst = PlusFifteenIdRefType;
            var other = Dependency.Create(_ => otherFirst, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdSource, otherFirst, otherLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}