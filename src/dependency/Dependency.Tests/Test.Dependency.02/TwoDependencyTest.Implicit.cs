#nullable enable

using System;
using Moq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void ImplicitToFirstResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<StructType?, RecordType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, StructType?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToFirstResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceFirstValue(
            StructType firstSource)
        {
            var source = Dependency.Create(_ => firstSource, _ => MinusFifteenIdRefType);
            var actual = (Func<IServiceProvider, StructType>)source;

            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());
            Assert.Equal(firstSource, actualValue);
        }

        [Fact]
        public void ImplicitToSecondResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<decimal, RefType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, RefType>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToSecondResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceSecondValue(
            RefType secondSource)
        {
            var source = Dependency.Create(_ => SomeTextStructType, _ => secondSource);
            var actual = (Func<IServiceProvider, RefType>)source;

            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());
            Assert.Equal(secondSource, actualValue);
        }
    }
}