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
        public void ImplicitToSecondResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<string?, StructType?, long, object[], RefType, RecordType?, DateTime, bool>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, StructType?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToSecondResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceSecondValue(
            RecordType secondSource)
        {
            var source = Dependency.Create(
                _ => decimal.MinValue,
                _ => secondSource,
                _ => LowerSomeTextStructType,
                _ => new { Text = UpperSomeString },
                _ => ZeroIdRefType,
                _ => false,
                _ => DateTimeKind.Unspecified,
                _ => byte.MaxValue);

            var actual = (Func<IServiceProvider, RecordType>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(secondSource, actualValue);
        }
    }
}