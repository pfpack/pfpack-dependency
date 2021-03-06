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
        public void ImplicitToSeventhResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<RefType?, long, string?, object?, RecordType, StructType, DateTimeOffset>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, DateTimeOffset>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(MinusFifteen)]
        [InlineData(int.MaxValue)]
        public void ImplicitToSeventhResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceSixthValue(
            int? seventhSource)
        {
            var source = Dependency.Create(
                _ => SomeTextStructType,
                _ => DateTimeKind.Utc,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => SomeTextStructType,
                _ => decimal.MinValue,
                _ => PlusFifteenIdRefType,
                _ => seventhSource);

            var actual = (Func<IServiceProvider, int?>)source;

            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());
            Assert.Equal(seventhSource, actualValue);
        }
    }
}