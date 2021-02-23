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
        public void ImplicitToFirstResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<string?, object, RecordType?, StructType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, string?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }
        
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToFirstResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceFirstValue(
            RefType? firstSource)
        {
            var source = Dependency.Create(
                _ => firstSource,
                _ => MinusFifteen,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => SomeTextStructType);

            var actual = (Func<IServiceProvider, RefType?>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(firstSource, actualValue);
        }

        [Fact]
        public void ImplicitToSecondResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<long, byte, RecordType, ValueType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, byte>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToSecondResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceSecondValue(
            StructType secondSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdRefType,
                _ => secondSource,
                _ => LowerSomeString,
                _ => PlusFifteenIdLowerSomeStringNameRecord);
            
            var actual = (Func<IServiceProvider, StructType>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(secondSource, actualValue);
        }

        [Fact]
        public void ImplicitToThirdResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<RefType?, object, decimal, DateTimeOffset?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, decimal>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(UpperSomeString)]
        public void ImplicitToThirdResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceThirdValue(
            string? thirdSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdNullNameRecord,
                _ => SomeTextStructType,
                _ => thirdSource,
                _ => ZeroIdRefType);

            var actual = (Func<IServiceProvider, string?>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(thirdSource, actualValue);
        }

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