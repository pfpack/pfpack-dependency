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
        public void ImplicitToFirstResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<RecordType, object, RefType?, decimal, StructType, string?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, RecordType>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToFirstResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceFirstValue(
            StructType firstSource)
        {
            var source = Dependency.Create(
                _ => firstSource,
                _ => UpperSomeString,
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => PlusFifteenIdRefType,
                _ => int.MaxValue,
                _ => new object());

            var actual = (Func<IServiceProvider, StructType>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(firstSource, actualValue);
        }

        [Fact]
        public void ImplicitToSecondResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<RefType, StructType?, string?, byte?, RecordType, DateTimeOffset?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, StructType?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToSecondResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceSecondValue(
            RefType? secondSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => secondSource,
                _ => DateTimeKind.Utc,
                _ => SomeTextStructType,
                _ => new { Id = PlusFifteen },
                _ => long.MaxValue);
            
            var actual = (Func<IServiceProvider, RefType?>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(secondSource, actualValue);
        }

        [Fact]
        public void ImplicitToThirdResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<object?, int, RefType, string?, RecordType?, StructType>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, RefType>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void ImplicitToThirdResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceThirdValue(
            RecordType thirdSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdRefType,
                _ => new object(),
                _ => thirdSource,
                _ => MinusFifteen,
                _ => UpperSomeString,
                _ => LowerSomeTextStructType);

            var actual = (Func<IServiceProvider, RecordType>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(thirdSource, actualValue);
        }

        [Fact]
        public void ImplicitToFourthResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<RecordType, string, object, long?, RefType, StructType?>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, long?>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(Zero)]
        [InlineData(PlusFifteen)]
        public void ImplicitToFourthResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceFourthValue(
            int fourthSource)
        {
            var source = Dependency.Create(
                _ => SomeTextStructType,
                _ => long.MaxValue,
                _ => PlusFifteenIdLowerSomeStringNameRecord,
                _ => fourthSource,
                _ => DateTimeKind.Local,
                _ => MinusFifteenIdRefType);
                
            var actual = (Func<IServiceProvider, int>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(fourthSource, actualValue);
        }

        [Fact]
        public void ImplicitToFifthResolver_DependencyIsNull_ExpectArgumentNullException()
        {
            var source = (Dependency<string, RecordType?, StructType?, DateTimeKind, RefType, object>)null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = (Func<IServiceProvider, RefType>)source);
            
            Assert.Equal("dependency", ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(SomeString)]
        public void ImplicitToFifthResolver_DependencyIsNotNull_ExpectResolvedValueIsEqualToSourceFifthValue(
            string? fifthSource)
        {
            var source = Dependency.Create(
                _ => ZeroIdRefType,
                _ => SomeTextStructType,
                _ => new object(),
                _ => ZeroIdNullNameRecord,
                _ => fifthSource,
                _ => PlusFifteen);
                
            var actual = (Func<IServiceProvider, string?>)source;
            var actualValue = actual.Invoke(Mock.Of<IServiceProvider>());

            Assert.Equal(fifthSource, actualValue);
        }

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