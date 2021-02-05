#nullable enable

using PrimeFuncPack.UnitTest;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.DependencyRegistry.Tests
{
    partial class DependencyRegistrarTest
    {
        [Fact]
        public void Create_ServicesAreNull_ExpectArgumentNullException()
        {            
            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = DependencyRegistrar.Create(null!, _ => PlusFifteenIdRefType));

            Assert.Equal("services", ex.ParamName);
        }

        [Fact]
        public void Create_ResolverIsNull_ExpectArgumentNullException()
        {       
            var mockServices = MockServiceCollection.CreateMock();
            var sourceServices = mockServices.Object;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = DependencyRegistrar.Create<RecordType>(sourceServices, null!));

            Assert.Equal("resolver", ex.ParamName);
        }
    }
}