using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void CreateWithProvider_FirstIsNull_ExpectArgumentNullException()
        {
            var second = ZeroIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<StructType, RefType>.Create(
                    null!,
                    _ => second));

            Assert.Equal("first", ex.ParamName);
        }

        [Fact]
        public void CreateWithProvider_SecondIsNull_ExpectArgumentNullException()
        {
            var first = SomeString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<string?, RecordType>.Create(
                    _ => first,
                    null!));

            Assert.Equal("second", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void CreateWithProvider_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
            RefType? sourceSecond)
        {
            var sourceFirst = new { Name = SomeString };

            var actual = Dependency<object, RefType?>.Create(
                _ => sourceFirst,
                _ => sourceSecond);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}