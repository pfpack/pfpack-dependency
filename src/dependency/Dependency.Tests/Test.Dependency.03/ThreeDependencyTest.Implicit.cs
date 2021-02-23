#nullable enable

using System;
using Moq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Fact]
        public void ImplicitToFirstResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<RecordType, int, RefType?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, RecordType>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToFirstResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceFirstValue(
            RefType? firstSource)
        {
            var source = Dependency.Create(_ => firstSource, _ => LowerSomeTextStructType, _ => ZeroIdNullNameRecord);
            var actual = (Func<IServiceProvider, RefType?>)source;

            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());
            Assert.Equal(firstSource, actualValue);
        }

        [Fact]
        public void ImplicitToSecondResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<string, DateTime?, StructType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, DateTime?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToSecondResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceSecondValue(
            RecordType? secondSource)
        {
            var source = Dependency.Create(_ => PlusFifteenIdRefType, _ => secondSource, _ => MinusFifteen);
            var actual = (Func<IServiceProvider, RecordType?>)source;

            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());
            Assert.Equal(secondSource, actualValue);
        }

        [Fact]
        public void ImplicitToThirdResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<long, string?, RecordType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, RecordType>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [InlineData(MinusFifteen)]
        [InlineData(Zero)]
        [InlineData(PlusFifteen)]
        public void ImplicitToThirdResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceThirdValue(
            int thirdSource)
        {
            var source = Dependency.Create(_ => MinusFifteenIdNullNameRecord, _ => PlusFifteenIdRefType, _ => thirdSource);
            var actual = (Func<IServiceProvider, int>)source;

            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());
            Assert.Equal(thirdSource, actualValue);
        }
    }
}