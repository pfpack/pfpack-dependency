#nullable enable

using System;
using Moq;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void ImplicitToResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<RefType?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, RefType?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceValue(
            RecordType? sourceValue)
        {
            var source = Dependency.Create(_ => sourceValue);
            var actual = (Func<IServiceProvider, RecordType?>)source;

            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());
            Assert.Equal(sourceValue, actualValue);
        }
    }
}