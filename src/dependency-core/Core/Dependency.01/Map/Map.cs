using System;

namespace PrimeFuncPack;

partial class Dependency<T>
{
    public Dependency<TResult> Map<TResult>(
        Func<T, TResult> map)
        =>
        InnerMap(
            map ?? throw new ArgumentNullException(nameof(map)));

    private Dependency<TResult> InnerMap<TResult>(
        Func<T, TResult> map)
        =>
        new(
            new(sp => sp.InternalResolveThenMap(resolver.Invoke, map)));
}