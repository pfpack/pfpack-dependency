#nullable enable

using PrimeFuncPack.UnitTest;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyRegistratorTest
    {
        [Fact]
        public void Create_ServicesAreNull_ExpectArgumentNullException()
        {            
            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = DependencyRegistrator.Create(null!, _ => PlusFifteenIdRefType));

            Assert.Equal("services", ex.ParamName);
        }

        [Fact]
        public void Create_ResolverIsNull_ExpectArgumentNullException()
        {       
            var mockServices = MockServiceCollection.CreateMock();
            var sourceServices = mockServices.Object;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = DependencyRegistrator.Create<RecordType>(sourceServices, null!));

            Assert.Equal("resolver", ex.ParamName);
        }
    }
}