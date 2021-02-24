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
        public void ImplicitToFirstResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<StructType, RefType?, RecordType, string, byte[]>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, StructType>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToFirstResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceFirstValue(
            RecordType? firstSource)
        {
            var source = Dependency.Create(
                _ => firstSource,
                _ => SomeTextStructType,
                _ => new object(),
                _ => Zero,
                _ => MinusFifteenIdRefType);

            var actual = (Func<IServiceProvider, RecordType?>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(firstSource, actualValue);
        }

        [Fact]
        public void ImplicitToSecondResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<long, RefType?, StructType, object, string?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, RefType?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(SomeString)]
        public void ImplicitToSecondResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceSecondValue(
            string secondSource)
        {
            var source = Dependency.Create(
                _ => PlusFifteen,
                _ => secondSource,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => MinusFifteenIdRefType,
                _ => new object());
            
            var actual = (Func<IServiceProvider, string>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(secondSource, actualValue);
        }

        [Fact]
        public void ImplicitToThirdResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<string, long, RecordType?, RefType, StructType?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, RecordType?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToThirdResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceThirdValue(
            StructType thirdSource)
        {
            var source = Dependency.Create(
                _ => TabString,
                _ => MinusFifteenIdNullNameRecord,
                _ => thirdSource,
                _ => new { Id = PlusFifteen },
                _ => ZeroIdNullNameRecord);

            var actual = (Func<IServiceProvider, StructType>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(thirdSource, actualValue);
        }

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

        [Fact]
        public void ImplicitToFifthResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<RefType?, StructType, decimal, RecordType, string[]?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, string[]?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(MinusFifteen)]
        [InlineData(int.MaxValue)]
        public void ImplicitToFifthResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceFifthValue(
            int? fifthSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteen,
                _ => PlusFifteenIdRefType,
                _ => ZeroIdNullNameRecord,
                _ => SomeString,
                _ => fifthSource);
                
            var actual = (Func<IServiceProvider, int?>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(fifthSource, actualValue);
        }
    }
}