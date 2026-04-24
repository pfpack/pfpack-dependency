using System;
using Moq;
using Xunit;

namespace PrimeFuncPack.Tests;

internal static class ServiceProviderTestSource
{
    public static TheoryData<IServiceProvider> NullableProviders
        =>
        new()
        {
            null!,
            Mock.Of<IServiceProvider>()
        };
}