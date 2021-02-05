#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void Create_01_SingleIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(NullStructResolver));

            Assert.Equal("single", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void Create_01_SingleResolverIsNotNull_ExpectResolvedValueIsSameAsSource(
            RefType? sourceSingle)
        {
            var actual = Dependency.Create(_ => sourceSingle);
            var actualValue = actual.Resolve();

            Assert.Equal(sourceSingle, actualValue);
        }
    }
}