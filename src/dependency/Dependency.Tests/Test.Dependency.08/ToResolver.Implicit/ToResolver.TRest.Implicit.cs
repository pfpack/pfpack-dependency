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
        public void ImplicitToRestResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<string?, byte?, object, RecordType, StructType, DateTimeKind, decimal, RefType?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, RefType?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToRestResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceSixthValue(
            RefType restSource)
        {
            var source = Dependency.Create(
                _ => NullTextStructType,
                _ => (true, MixedWhiteSpacesString),
                _ => new { Id = PlusFifteen },
                _ => long.MinValue,
                _ => false,
                _ => decimal.One,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => restSource);

            var actual = (Func<IServiceProvider, RefType?>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(restSource, actualValue);
        }
    }
}