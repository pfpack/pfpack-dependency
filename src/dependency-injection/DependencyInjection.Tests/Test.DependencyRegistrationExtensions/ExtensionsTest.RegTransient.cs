#nullable enable

using Microsoft.Extensions.DependencyInjection;
using Moq;
using PrimeFuncPack.UnitTest;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyRegistrationExtensionsTest
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RegisterTransient_ExpectSourceServices(
            bool isNotNull)
        {            
            var mockServices = MockServiceCollection.CreateMock();
            var sourceServices = mockServices.Object;
            
            RecordType regService = isNotNull ? ZeroIdNullNameRecord : null!;
            var dependecy = Dependency.Create(_ => regService);

            var registrar = dependecy.ToRegistrar(sourceServices);

            var actualServices = registrar.RegisterTransient();
            Assert.Same(sourceServices, actualServices);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RegisterTransient_ExpectCallAddTransientOnce(
            bool isNotNull)
        {
            string regService = isNotNull ? LowerSomeString: null!;
            var mockServices = MockServiceCollection.CreateMock(
                sd =>
                {
                    Assert.Equal(typeof(string), sd.ServiceType);
                    Assert.Equal(ServiceLifetime.Transient, sd.Lifetime);
                    Assert.NotNull(sd.ImplementationFactory);

                    var actualService = sd.ImplementationFactory!.Invoke(Mock.Of<IServiceProvider>());
                    Assert.Equal(regService, actualService);
                });

            var sourceServices = mockServices.Object;            
            var dependecy = Dependency.Create(_ => regService);

            var registrar = dependecy.ToRegistrar(sourceServices);
            _ = registrar.RegisterTransient();
            
            mockServices.Verify(s => s.Add(It.IsAny<ServiceDescriptor>()), Times.Once);
        }
    }
}