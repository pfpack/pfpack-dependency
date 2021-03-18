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
        public void ImplicitToSixthResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<RecordType, int, string?, DateTimeKind, object?, StructType?, long, RefType?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, StructType?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToSixthResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceSixthValue(
            RecordType? sixthSource)
        {
            var source = Dependency.Create(
                _ => WhiteSpaceString,
                _ => SomeTextStructType,
                _ => false,
                _ => new object(),
                _ => decimal.MinusOne,
                _ => sixthSource,
                _ => MinusFifteenIdRefType,
                _ => DateTimeKind.Local);

            var actual = (Func<IServiceProvider, RecordType?>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(sixthSource, actualValue);
        }
    }
}