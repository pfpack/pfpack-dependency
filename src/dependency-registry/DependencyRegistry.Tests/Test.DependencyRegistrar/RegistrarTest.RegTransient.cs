#nullable enable

using Microsoft.Extensions.DependencyInjection;
using Moq;
using PrimeFuncPack.UnitTest;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.DependencyRegistry.Tests
{
    partial class DependencyRegistrarTest
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RegisterTransient_ExpectSourceServices(
            bool isNotNull)
        {            
            var mockServices = MockServiceCollection.CreateMock();
            var sourceServices = mockServices.Object;
            
            RecordType regService = isNotNull ? PlusFifteenIdSomeStringNameRecord : null!;
            var registrar = DependencyRegistrar.Create(
                sourceServices,
                _ => regService);

            var actualServices = registrar.RegisterTransient();
            Assert.Same(sourceServices, actualServices);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RegisterTransient_ExpectCallAddTransientOnce(
            bool isNotNull)
        {
            RefType regService = isNotNull ? MinusFifteenIdRefType : null!;
            var mockServices = MockServiceCollection.CreateMock(
                sd =>
                {
                    Assert.Equal(typeof(RefType), sd.ServiceType);
                    Assert.Equal(ServiceLifetime.Transient, sd.Lifetime);
                    Assert.NotNull(sd.ImplementationFactory);

                    var actualService = sd.ImplementationFactory!.Invoke(Mock.Of<IServiceProvider>());
                    Assert.Equal(regService, actualService);
                });

            var sourceServices = mockServices.Object;
            
            var registrar = DependencyRegistrar.Create(
                sourceServices,
                _ => regService);

            _ = registrar.RegisterTransient();
            mockServices.Verify(s => s.Add(It.IsAny<ServiceDescriptor>()), Times.Once);
        }
    }
}