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
        public void ImplicitToFourthResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<RecordType, string, object, long?, RefType, StructType?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, long?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(Zero)]
        [InlineData(PlusFifteen)]
        public void ImplicitToFourthResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceFourthValue(
            int fourthSource)
        {
            var source = Dependency.Create(
                _ => SomeTextStructType,
                _ => long.MaxValue,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => fourthSource,
                _ => DateTimeKind.Local,
                _ => MinusFifteenIdRefType);
                
            var actual = (Func<IServiceProvider, int>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(fourthSource, actualValue);
        }
    }
}