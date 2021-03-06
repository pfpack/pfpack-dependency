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
        public void ImplicitToSixthResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<string?, StructType, object, RefType, DateTimeKind?, RecordType, bool>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, RecordType>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToSixthResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceSixthValue(
            RefType? sixthSource)
        {
            var source = Dependency.Create(
                _ => ZeroIdNullNameRecord,
                _ => PlusFifteen,
                _ => new object(),
                _ => decimal.MaxValue,
                _ => true,
                _ => sixthSource,
                _ => LowerSomeTextStructType);

            var actual = (Func<IServiceProvider, RefType?>)source;

            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());
            Assert.Equal(sixthSource, actualValue);
        }
    }
}