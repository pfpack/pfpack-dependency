#nullable enable

using System;
using Moq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Fact]
        public void ImplicitToFifthResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<string, RecordType?, StructType?, DateTimeKind, RefType, object>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, RefType>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(SomeString)]
        public void ImplicitToFifthResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceFifthValue(
            string? fifthSource)
        {
            var source = Dependency.Create(
                _ => ZeroIdRefType,
                _ => SomeTextStructType,
                _ => new object(),
                _ => ZeroIdNullNameRecord,
                _ => fifthSource,
                _ => PlusFifteen);
                
            var actual = (Func<IServiceProvider, string?>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(fifthSource, actualValue);
        }
    }
}