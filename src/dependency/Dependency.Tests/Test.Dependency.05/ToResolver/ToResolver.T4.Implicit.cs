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
        public void ImplicitToFourthResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<int, DateTimeKind?, StructType, object, RecordType?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, object>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToFourthResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceFourthValue(
            RefType? fourthSource)
        {
            var source = Dependency.Create(
                _ => ThreeWhiteSpacesString,
                _ => DateTimeKind.Unspecified,
                _ => SomeTextStructType,
                _ => fourthSource,
                _ => MinusFifteenIdSomeStringNameRecord);
                
            var actual = (Func<IServiceProvider, RefType?>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(fourthSource, actualValue);
        }
    }
}