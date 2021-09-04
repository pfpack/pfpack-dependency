#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void CreateWithProvider_SingleIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RefType?>.Create(
                    null!));

            Assert.Equal("single", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void CreateWithProvider_SingleIsNotNull_ExpectResolvedValuesAreEqualToSource(
            StructType sourceSingle)
        {
            var actual = Dependency<StructType>.Create(
                _ => sourceSingle);

            var actualValue = actual.Resolve();

            var expectedValue = sourceSingle;
            Assert.Equal(expectedValue, actualValue);
        }
    }
}