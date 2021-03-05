#nullable enable

using System;
using Moq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FourDependencyTest
    {
        [Fact]
        public void ImplicitToFourthResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<RecordType, StructType?, string, RefType?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, RefType?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToFourthResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceFourthValue(
            RecordType? fourthSource)
        {
            var source = Dependency.Create(
                _ => PlusFifteen,
                _ => SomeTextStructType,
                _ => MinusFifteenIdRefType,
                _ => fourthSource);
                
            var actual = (Func<IServiceProvider, RecordType?>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(fourthSource, actualValue);
        }
    }
}