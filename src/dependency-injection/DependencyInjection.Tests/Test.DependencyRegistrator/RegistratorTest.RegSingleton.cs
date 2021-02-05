#nullable enable

using Microsoft.Extensions.DependencyInjection;
using Moq;
using PrimeFuncPack.UnitTest;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyRegistratorTest
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RegisterSingleton_ExpectSourceServices(
            bool isNotNull)
        {            
            var mockServices = MockServiceCollection.CreateMock();
            var sourceServices = mockServices.Object;
            
            object regService = isNotNull ? new object() : null!;
            var registrator = DependencyRegistrator.Create(
                sourceServices,
                _ => regService);

            var actualServices = registrator.RegisterSingleton();
            Assert.Same(sourceServices, actualServices);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RegisterSingleton_ExpectCallAddSingletonOnce(
            bool isNotNull)
        {
            RecordType regService = isNotNull ? PlusFifteenIdLowerSomeStringNameRecord : null!;
            var mockServices = MockServiceCollection.CreateMock(
                sd =>
                {
                    Assert.Equal(typeof(RecordType), sd.ServiceType);
                    Assert.Equal(ServiceLifetime.Singleton, sd.Lifetime);
                    Assert.NotNull(sd.ImplementationFactory);

                    var actualService = sd.ImplementationFactory!.Invoke(Mock.Of<IServiceProvider>());
                    Assert.Equal(regService, actualService);
                });

            var sourceServices = mockServices.Object;
            
            var registrator = DependencyRegistrator.Create(
                sourceServices,
                _ => regService);

            _ = registrator.RegisterSingleton();
            mockServices.Verify(s => s.Add(It.IsAny<ServiceDescriptor>()), Times.Once);
        }
    }
}