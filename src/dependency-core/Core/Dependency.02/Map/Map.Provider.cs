using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    public Dependency<TResult1, TResult2> Map<TResult1, TResult2>(
        Func<IServiceProvider, T1, TResult1> mapFirst,
        Func<IServiceProvider, T2, TResult2> mapSecond)
        =>
        InnerMap(
            mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
            mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)));

    private Dependency<TResult1, TResult2> InnerMap<TResult1, TResult2>(
        Func<IServiceProvider, T1, TResult1> mapFirst,
        Func<IServiceProvider, T2, TResult2> mapSecond)
        =>
        new(
            new(sp => sp.InternalPipe(firstResolver.Invoke).InternalPipe(first => mapFirst.Invoke(sp, first))),
            new(sp => sp.InternalPipe(secondResolver.Invoke).InternalPipe(second => mapSecond.Invoke(sp, second))));
}