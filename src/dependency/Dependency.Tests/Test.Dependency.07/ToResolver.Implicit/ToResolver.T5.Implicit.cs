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
        public void ImplicitToFifthResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<RefType?, long, StructType, string, object?, RecordType, DateTime?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, object?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(false)]
        [InlineData(true)]
        public void ImplicitToFifthResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceFifthValue(
            bool? fifthSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdRefType,
                _ => DateTimeKind.Local,
                _ => UpperSomeString,
                _ => SomeTextStructType,
                _ => fifthSource,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => new { Id = PlusFifteen, Text = WhiteSpaceString });
                
            var actual = (Func<IServiceProvider, bool?>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(fifthSource, actualValue);
        }
    }
}