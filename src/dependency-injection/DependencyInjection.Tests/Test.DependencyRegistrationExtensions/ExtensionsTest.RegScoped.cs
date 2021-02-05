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
        public void RegisterScoped_ExpectSourceServices(
            bool isNotNull)
        {            
            var mockServices = MockServiceCollection.CreateMock();
            var sourceServices = mockServices.Object;
            
            RefType regService = isNotNull ? ZeroIdRefType : null!;
            var dependency = Dependency.Create(_ => regService);

            var registrar = dependency.ToRegistrar(sourceServices);

            var actualServices = registrar.RegisterScoped();
            Assert.Same(sourceServices, actualServices);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RegisterScoped_ExpectCallAddScopedOnce(
            bool isNotNull)
        {
            RecordType regService = isNotNull ? MinusFifteenIdSomeStringNameRecord: null!;
            var mockServices = MockServiceCollection.CreateMock(
                sd =>
                {
                    Assert.Equal(typeof(RecordType), sd.ServiceType);
                    Assert.Equal(ServiceLifetime.Scoped, sd.Lifetime);
                    Assert.NotNull(sd.ImplementationFactory);

                    var actualService = sd.ImplementationFactory!.Invoke(Mock.Of<IServiceProvider>());
                    Assert.Equal(regService, actualService);
                });

            var sourceServices = mockServices.Object;
            var dependency = Dependency.Create(_ => regService);

            var registrar = dependency.ToRegistrar(sourceServices);
            _ = registrar.RegisterScoped();
            
            mockServices.Verify(s => s.Add(It.IsAny<ServiceDescriptor>()), Times.Once);
        }
    }
}