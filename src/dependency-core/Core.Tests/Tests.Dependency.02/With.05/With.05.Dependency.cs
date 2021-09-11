using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void WithThreeDependency_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => SomeTextStructType, _ => long.MaxValue);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With<RecordType?, StructType, decimal>(null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithThreeDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType? otherLast)
        {
            var firstSource = default(StructType);
            var secondSource = MinusFifteenIdNullNameRecord;
            var source = Dependency.From(_ => firstSource, _ => secondSource);
            
            var otherFirst = decimal.One;
            var otherSecond = PlusFifteen;
            var other = Dependency.From(_ => otherFirst, _ => otherSecond, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, otherFirst, otherSecond, otherLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}