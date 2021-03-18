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
        public void ImplicitToThirdResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<RecordType?, DateTimeOffset, string, decimal?, object, byte, RefType?, StructType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, string>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToThirdResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceThirdValue(
            RefType? thirdSource)
        {
            var source = Dependency.Create(
                _ => (MinusFifteen, LowerSomeString),
                _ => ZeroIdNullNameRecord,
                _ => thirdSource,
                _ => Array.Empty<DateTime>(),
                _ => new { Id = byte.MaxValue },
                _ => SomeTextStructType,
                _ => new Tuple<string, DateTimeKind>(UpperSomeString, DateTimeKind.Local),
                _ => true);

            var actual = (Func<IServiceProvider, RefType?>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(thirdSource, actualValue);
        }
    }
}