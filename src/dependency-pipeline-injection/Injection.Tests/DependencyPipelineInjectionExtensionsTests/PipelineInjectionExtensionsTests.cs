#nullable enable

using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;

namespace PrimeFuncPack.Tests
{
    public sealed partial class PipelineInjectionExtensionsTests
    {
        private static Mock<IServiceCollection> CreateMockServiceCollection(
            in Action<ServiceDescriptor>? callback = null)
        {
            var mock = new Mock<IServiceCollection>();

            var m = mock.Setup(s => s.Add(It.IsAny<ServiceDescriptor>()));

            if (callback is object)
            {
                _ = m.Callback(callback);
            }

            return mock;
        }

        private static Mock<IServiceProvider> CreateMockServiceProvider(
            in object? resultValue)
        {
            var mock = new Mock<IServiceProvider>();

            _ = mock
                .Setup(sp => sp.GetService(It.IsAny<Type>()))
                .Returns(resultValue);

            return mock;
        }
    }
}
