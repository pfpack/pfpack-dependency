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
        public void ImplicitToThirdResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<RecordType, StructType, long, object?, RefType?, DateTimeOffset?, byte>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, long>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToThirdResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceThirdValue(
            StructType thirdSource)
        {
            var source = Dependency.Create(
                _ => long.MinValue,
                _ => SomeString,
                _ => thirdSource,
                _ => PlusFifteenIdSomeStringNameRecord,
                _ => ZeroIdRefType,
                _ => new { Name = LowerSomeString },
                _ => DateTimeKind.Unspecified);

            var actual = (Func<IServiceProvider, StructType>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(thirdSource, actualValue);
        }
    }
}