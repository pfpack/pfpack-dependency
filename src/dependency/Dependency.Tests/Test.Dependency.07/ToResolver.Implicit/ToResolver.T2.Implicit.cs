#nullable enable

using System;
using Moq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SevenDependencyTest
    {
        [Fact]
        public void ImplicitToSecondResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<object?, RecordType, DateTimeOffset, long, RefType?, StructType, decimal>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, RecordType>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(SomeString)]
        public void ImplicitToSecondResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceSecondValue(
            string? secondSource)
        {
            var source = Dependency.Create(
                _ => ZeroIdRefType,
                _ => secondSource,
                _ => decimal.MaxValue,
                _ => PlusFifteenIdRefType,
                _ => MinusFifteenIdNullNameRecord,
                _ => byte.MaxValue,
                _ =>  new object());
            
            var actual = (Func<IServiceProvider, string>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(secondSource, actualValue);
        }
    }
}