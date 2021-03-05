#nullable enable

using System;
using Moq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Fact]
        public void ImplicitToFifthResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<RefType?, StructType, decimal, RecordType, string[]?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, string[]?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(MinusFifteen)]
        [InlineData(int.MaxValue)]
        public void ImplicitToFifthResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceFifthValue(
            int? fifthSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteen,
                _ => PlusFifteenIdRefType,
                _ => ZeroIdNullNameRecord,
                _ => SomeString,
                _ => fifthSource);
                
            var actual = (Func<IServiceProvider, int?>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(fifthSource, actualValue);
        }
    }
}