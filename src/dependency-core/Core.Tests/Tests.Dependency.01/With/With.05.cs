using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void WithFour_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => SomeString);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<StructType, RecordType, object, RecordType?>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithFour_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType? otherLast)
        {
            var sourceValue = int.MinValue;
            var source = Dependency.Create(_ => sourceValue);
            
            var otherFirst = ZeroIdNullNameRecord;
            var otherSecond = PlusFifteen;

            var otherThird = NullTextStructType;
            var other = Dependency.Create(_ => otherFirst, _ => otherSecond, _ => otherThird, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceValue, otherFirst, otherSecond, otherThird, otherLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}