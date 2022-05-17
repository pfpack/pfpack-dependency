using System;

namespace PrimeFuncPack;

internal static class InternalServiceProviderExtensions
{
    internal static TResult InternalResolveThenMap<T, TResult>(
        this IServiceProvider serviceProvider,
        Func<IServiceProvider, T> resolver,
        Func<T, TResult> map)
        =>
        serviceProvider.InternalPipe(resolver).InternalPipe(map);

    internal static TResult InternalResolveThenMap<T, TResult>(
        this IServiceProvider serviceProvider,
        Func<IServiceProvider, T> resolver,
        Func<IServiceProvider, T, TResult> map)
        =>
        serviceProvider.InternalPipe(resolver).InternalPipe(dependency => map.Invoke(serviceProvider, dependency));
}
