#nullable enable

using PrimeFuncPack.UnitTest;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyRegistrationExtensionsTest
    {
        [Fact]
        public void ToRegistrator_DependencyIsNull_ExpectArgumentNullException()
        {
            var mockServices = MockServiceCollection.CreateMock();
            var sourceServices = mockServices.Object;

            Dependency<RefType> dependency = null!;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = dependency.ToRegistrator(sourceServices));

            Assert.Equal("dependency", ex.ParamName);
        }

        [Fact]
        public void ToRegistrator_ServicesAreNull_ExpectArgumentNullException()
        {
            var dependency = Dependency.Create(
                _ => MinusFifteenIdSomeStringNameRecord);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = dependency.ToRegistrator(null!));

            Assert.Equal("services", ex.ParamName);
        }
    }
}