#nullable enable

using System;
using Moq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class EightDependencyTest
    {
        [Fact]
        public void ImplicitToFifthResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<long, object?, RefType?, string, decimal, int, StructType, RecordType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, decimal>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(MinusOne)]
        [InlineData(One)]
        public void ImplicitToFifthResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceFifthValue(
            int? fifthSource)
        {
            var source = Dependency.Create(
                _ => new { Name = UpperSomeString },
                _ => DateTimeKind.Unspecified,
                _ => long.MinValue,
                _ => MinusFifteenIdNullNameRecord,
                _ => fifthSource,
                _ => MinusFifteenIdRefType,
                _ => byte.MaxValue,
                _ => LowerSomeTextStructType);

            var actual = (Func<IServiceProvider, int?>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(fifthSource, actualValue);
        }
    }
}