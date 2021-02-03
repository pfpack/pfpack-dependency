#nullable enable

using Microsoft.Extensions.DependencyInjection;
using Moq;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class PipelineInjectionExtensionsTests
    {
        [Fact]
        public void InjectScoped_SourcePipelineIsNull_ExpectArgumentNullException()
        {
            DependencyPipeline<RefType> sourcePipeline = null!;
            var mockServices = CreateMockServiceCollection();

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.InjectScoped(mockServices.Object));
            Assert.Equal("sourcePipeline", ex.ParamName);
        }

        [Fact]
        public void InjectScoped_ServicesAreNull_ExpectArgumentNullException()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(ZeroIdRefType);
            var sourcePipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.InjectScoped(null!));
            Assert.Equal("services", ex.ParamName);
        }

        [Fact]
        public void InjectScoped_ExpectCallAddScopedOnce()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(PlusFifteenIdRefType);
            var sourcePipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            var mockServices = CreateMockServiceCollection(actualDescriptor =>
            {
                Assert.Equal(typeof(RefType), actualDescriptor.ServiceType);
                Assert.Equal(ServiceLifetime.Scoped, actualDescriptor.Lifetime);
                Assert.NotNull(actualDescriptor.ImplementationFactory);
            });

            _ = sourcePipeline.InjectScoped(mockServices.Object);
            mockServices.Verify(s => s.Add(It.IsAny<ServiceDescriptor>()), Times.Once);
        }

        [Fact]
        public void InjectScoped_ThenInvokeImplementationFactory_ExpectResolvedValue()
        {
            var resolved = MinusFifteenIdRefType;
            var mockResolver = MockFuncFactory.CreateMockResolver(resolved);
            var sourcePipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            var mockServices = CreateMockServiceCollection(sd =>
            {
                var actualFactory = sd.ImplementationFactory!;
                var serviceProvider = Mock.Of<IServiceProvider>();
                var actual = actualFactory.Invoke(serviceProvider);

                Assert.Equal(resolved, actual);
            });

            _ = sourcePipeline.InjectScoped(mockServices.Object);
        }

        [Fact]
        public void InjectScoped_ThenResolve_ExpectGetServiceFromProviderOnce()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(ZeroIdRefType);
            var sourcePipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            var mockServices = CreateMockServiceCollection();
            var actualPipeline = sourcePipeline.InjectScoped(mockServices.Object);

            var mockServiceProvider = CreateMockServiceProvider(PlusFifteenIdRefType);
            _ = actualPipeline.Resolve(mockServiceProvider.Object);

            mockServiceProvider.Verify(sp => sp.GetService(typeof(RefType)), Times.Once);
        }

        [Fact]
        public void InjectScoped_ThenResolve_ServiceFromProviderIsNull_ExpectInvalidOperationException()
        {
            var resolved = PlusFifteenIdRefType;
            var mockResolver = MockFuncFactory.CreateMockResolver(resolved);
            var sourcePipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            var mockServices = CreateMockServiceCollection();
            var actualPipeline = sourcePipeline.InjectScoped(mockServices.Object);

            var mockServiceProvider = CreateMockServiceProvider(null);
            var ex = Assert.Throws<InvalidOperationException>(() => _ = actualPipeline.Resolve(mockServiceProvider.Object));

            Assert.Contains(typeof(RefType).FullName, ex.Message, StringComparison.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void InjectScoped_ThenResolve_ExpectValueFromServiceProvider()
        {
            var resolved = ZeroIdRefType;
            var sourcePipeline = new DependencyPipeline<RefType>(_ => resolved);

            var mockServices = CreateMockServiceCollection();
            var actualPipeline = sourcePipeline.InjectScoped(mockServices.Object);

            var valueFromProvider = PlusFifteenIdRefType;
            var mockServiceProvider = CreateMockServiceProvider(valueFromProvider);

            var actual = actualPipeline.Resolve(mockServiceProvider.Object);
            Assert.Same(valueFromProvider, actual);
        }

        [Fact]
        public void CompleteScoped_SourcePipelineIsNull_ExpectArgumentNullException()
        {
            DependencyPipeline<string> sourcePipeline = null!;
            var mockServices = CreateMockServiceCollection();

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.CompleteScoped(mockServices.Object));
            Assert.Equal("sourcePipeline", ex.ParamName);
        }

        [Fact]
        public void CompleteScoped_ServicesAreNull_ExpectArgumentNullException()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(PlusFifteenIdRefType);
            var sourcePipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.CompleteScoped(null!));
            Assert.Equal("services", ex.ParamName);
        }

        [Fact]
        public void CompleteScoped_ExpectCallAddScopedOnce()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(ZeroIdRefType);
            var sourcePipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            var mockServices = CreateMockServiceCollection(actualDescriptor =>
            {
                Assert.Equal(typeof(RefType), actualDescriptor.ServiceType);
                Assert.Equal(ServiceLifetime.Scoped, actualDescriptor.Lifetime);
                Assert.NotNull(actualDescriptor.ImplementationFactory);
            });

            _ = sourcePipeline.CompleteScoped(mockServices.Object);
            mockServices.Verify(s => s.Add(It.IsAny<ServiceDescriptor>()), Times.Once);
        }

        [Fact]
        public void CompleteScoped_ThenInvokeImplementationFactory_ExpectResolvedValue()
        {
            var resolved = MinusFifteenIdRefType;
            var mockResolver = MockFuncFactory.CreateMockResolver(resolved);
            var sourcePipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            var mockServices = CreateMockServiceCollection(sd =>
            {
                var actualFactory = sd.ImplementationFactory!;
                var serviceProvider = Mock.Of<IServiceProvider>();
                var actual = actualFactory.Invoke(serviceProvider);

                Assert.Same(resolved, actual);
            });

            _ = sourcePipeline.CompleteScoped(mockServices.Object);
        }

        [Fact]
        public void CompleteScoped_ExpectServicesAreSame()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(PlusFifteenIdRefType);
            var sourcePipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            var mockServices = CreateMockServiceCollection();
            var sourceServices = mockServices.Object;

            var actual = sourcePipeline.CompleteScoped(sourceServices);
            Assert.Same(sourceServices, actual);
        }
    }
}
