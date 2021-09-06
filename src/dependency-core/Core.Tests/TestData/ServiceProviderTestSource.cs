using Moq;

namespace PrimeFuncPack.Tests;

internal static class ServiceProviderTestSource
{
    public static IEnumerable<object?[]> NullableProviders
        =>
        new[]
        {
            null,
            Mock.Of<IServiceProvider>()
        }
        .Select(
            sp => new object?[] { sp });
}