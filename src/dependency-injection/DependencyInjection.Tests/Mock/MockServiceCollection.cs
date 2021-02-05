#nullable enable

using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;

namespace PrimeFuncPack.Tests
{
    internal sealed class MockServiceCollection
    {
        public static Mock<IServiceCollection> CreateMock(
            Action<ServiceDescriptor>? callback = null)
        {
            var mock = new Mock<IServiceCollection>();

            var m = mock.Setup(s => s.Add(It.IsAny<ServiceDescriptor>()));

            if (callback is object)
            {
                _ = m.Callback(callback);
            }

            return mock;
        }
    }
}