using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void WithThree_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => int.MaxValue);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<string, RecordType?, StructType>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithThree_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType otherLast)
        {
            var sourceValue = SomeTextStructType;
            var source = Dependency.Create(_ => sourceValue);
            
            var otherFirst = PlusFifteenIdRefType;
            var otherSecond = MinusFifteen;
            var other = Dependency.Create(_ => otherFirst, _ => otherSecond, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceValue, otherFirst, otherSecond, otherLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}