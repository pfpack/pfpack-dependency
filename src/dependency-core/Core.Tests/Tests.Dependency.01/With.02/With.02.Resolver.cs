using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void WithOneResolver_SecondIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => MinusFifteenIdSomeStringNameRecord);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With((Func<IServiceProvider, DateTimeOffset?>)null!));
            
            Assert.Equal("second", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithOneResolver_SecondIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType? secondValue)
        {
            var sourceValue = SomeTextStructType;
            var source = Dependency.Create(_ => sourceValue);

            var actual = source.With(_ => secondValue);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceValue, secondValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}