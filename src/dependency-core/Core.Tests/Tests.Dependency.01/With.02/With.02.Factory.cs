using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void WithOneFactory_SecondIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => ZeroIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With((Func<int>)null!));
            
            Assert.Equal("second", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void WithOneFactory_SecondIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            StructType secondValue)
        {
            var sourceValue = PlusFifteenIdSomeStringNameRecord;
            var source = Dependency.Create(_ => sourceValue);

            var actual = source.With(() => secondValue);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceValue, secondValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}