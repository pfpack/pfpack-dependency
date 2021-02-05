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
        public void RegisterSingleton_ExpectSourceServices(
            bool isNotNull)
        {            
            var mockServices = MockServiceCollection.CreateMock();
            var sourceServices = mockServices.Object;
            
            RefType regService = isNotNull ? MinusFifteenIdRefType : null!;
            var dependecy = Dependency.Create(_ => regService);

            var registrar = dependecy.ToRegistrar(sourceServices);

            var actualServices = registrar.RegisterSingleton();
            Assert.Same(sourceServices, actualServices);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RegisterSingleton_ExpectCallAddSingletonOnce(
            bool isNotNull)
        {
            object regService = isNotNull ? MinusFifteenIdNullNameRecord: null!;
            var mockServices = MockServiceCollection.CreateMock(
                sd =>
                {
                    Assert.Equal(typeof(object), sd.ServiceType);
                    Assert.Equal(ServiceLifetime.Singleton, sd.Lifetime);
                    Assert.NotNull(sd.ImplementationFactory);

                    var actualService = sd.ImplementationFactory!.Invoke(Mock.Of<IServiceProvider>());
                    Assert.Equal(regService, actualService);
                });

            var sourceServices = mockServices.Object;
            var dependecy = Dependency.Create(_ => regService);

            var registrar = dependecy.ToRegistrar(sourceServices);
            _ = registrar.RegisterSingleton();
            
            mockServices.Verify(s => s.Add(It.IsAny<ServiceDescriptor>()), Times.Once);
        }
    }
}