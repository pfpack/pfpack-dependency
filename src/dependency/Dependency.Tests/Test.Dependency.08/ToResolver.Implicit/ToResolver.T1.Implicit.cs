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
        public void ImplicitToFirstResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<RecordType, object?, RefType, int?, long?, Tuple<string, int>, string?, StructType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, RecordType>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(SomeString)]
        public void ImplicitToFirstResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceFirstValue(
            string? firstSource)
        {
            var source = Dependency.Create(
                _ => firstSource,
                _ => SomeTextStructType,
                _ => new object(),
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => decimal.MinusOne,
                _ => PlusFifteenIdRefType,
                _ => long.MaxValue,
                _ => new[] { false, true, true });

            var actual = (Func<IServiceProvider, string>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(firstSource, actualValue);
        }
    }
}