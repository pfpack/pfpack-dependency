#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void Create_01_FirstIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(NullStructResolver));

            Assert.Equal("first", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void Create_01_ResolverIsNotNull_ExpectResolvedValueIsSameAsSource(
            RefType? sourceValue)
        {
            var actual = Dependency.Create(_ => sourceValue);
            var actualValue = actual.Resolve();

            Assert.Equal(sourceValue, actualValue);
        }
    }
}