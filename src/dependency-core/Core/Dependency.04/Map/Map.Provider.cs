using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4>
{
    public Dependency<TResult1, TResult2, TResult3, TResult4> Map<TResult1, TResult2, TResult3, TResult4>(
        Func<IServiceProvider, T1, TResult1> mapFirst,
        Func<IServiceProvider, T2, TResult2> mapSecond,
        Func<IServiceProvider, T3, TResult3> mapThird,
        Func<IServiceProvider, T4, TResult4> mapFourth)
        =>
        InnerMap(
            mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
            mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
            mapThird ?? throw new ArgumentNullException(nameof(mapThird)),
            mapFourth ?? throw new ArgumentNullException(nameof(mapFourth)));

    private Dependency<TResult1, TResult2, TResult3, TResult4> InnerMap<TResult1, TResult2, TResult3, TResult4>(
        Func<IServiceProvider, T1, TResult1> mapFirst,
        Func<IServiceProvider, T2, TResult2> mapSecond,
        Func<IServiceProvider, T3, TResult3> mapThird,
        Func<IServiceProvider, T4, TResult4> mapFourth)
        =>
        new(
            new(sp => sp.InternalResolveThenMap(firstResolver.Invoke, mapFirst)),
            new(sp => sp.InternalResolveThenMap(secondResolver.Invoke, mapSecond)),
            new(sp => sp.InternalResolveThenMap(thirdResolver.Invoke, mapThird)),
            new(sp => sp.InternalResolveThenMap(fourthResolver.Invoke, mapFourth)));
}