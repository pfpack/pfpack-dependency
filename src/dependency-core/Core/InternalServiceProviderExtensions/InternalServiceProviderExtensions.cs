using System;

namespace PrimeFuncPack;

internal static class InternalServiceProviderExtensions
{
    internal static TResult InternalResolveThenMap<T, TResult>(
        this IServiceProvider sp,
        Func<IServiceProvider, T> resolver,
        Func<T, TResult> map)
        =>
        sp.InternalPipe(resolver).InternalPipe(map);

    internal static TResult InternalResolveThenMap<T, TResult>(
        this IServiceProvider sp,
        Func<IServiceProvider, T> resolver,
        Func<IServiceProvider, T, TResult> map)
        =>
        sp.InternalPipe(resolver).InternalPipe(dependency => map.Invoke(sp, dependency));
}
