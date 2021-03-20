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
        public void ImplicitToSixthResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<object, long?, RefType?, StructType, RefType, DateTimeKind?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, DateTimeKind?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToSixthResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceSixthValue(
            RecordType? sixthSource)
        {
            var source = Dependency.Create(
                _ => new { Text = SomeString },
                _ => MinusFifteenIdRefType,
                _ => WhiteSpaceString,
                _ => SomeTextStructType,
                _ => PlusFifteen,
                _ => sixthSource);

            var actual = (Func<IServiceProvider, RecordType>)source;

            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());
            Assert.Equal(sixthSource, actualValue);
        }
    }
}