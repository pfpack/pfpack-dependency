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
        public void ImplicitToSeventhResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<bool, RecordType?, decimal?, StructType?, long?, RefType, DateTime, DateTimeOffset>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, DateTime>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(false)]
        [InlineData(true)]
        public void ImplicitToSeventhResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceSixthValue(
            bool? seventhSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteen,
                _ => new object(),
                _ => LowerSomeTextStructType,
                _ => ZeroIdNullNameRecord,
                _ => UpperSomeString,
                _ => PlusFifteenIdRefType,
                _ => seventhSource,
                _ => long.MaxValue);

            var actual = (Func<IServiceProvider, bool?>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(seventhSource, actualValue);
        }
    }
}