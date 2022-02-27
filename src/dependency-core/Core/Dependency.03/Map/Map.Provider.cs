using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3>
{
    public Dependency<TResult1, TResult2, TResult3> Map<TResult1, TResult2, TResult3>(
        Func<IServiceProvider, T1, TResult1> mapFirst,
        Func<IServiceProvider, T2, TResult2> mapSecond,
        Func<IServiceProvider, T3, TResult3> mapThird)
        =>
        InnerMap(
            mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
            mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
            mapThird ?? throw new ArgumentNullException(nameof(mapThird)));

    private Dependency<TResult1, TResult2, TResult3> InnerMap<TResult1, TResult2, TResult3>(
        Func<IServiceProvider, T1, TResult1> mapFirst,
        Func<IServiceProvider, T2, TResult2> mapSecond,
        Func<IServiceProvider, T3, TResult3> mapThird)
        =>
        new(
            new(sp => sp.InternalPipe(firstResolver.Invoke).InternalPipe(first => mapFirst.Invoke(sp, first))),
            new(sp => sp.InternalPipe(secondResolver.Invoke).InternalPipe(second => mapSecond.Invoke(sp, second))),
            new(sp => sp.InternalPipe(thirdResolver.Invoke).InternalPipe(third => mapThird.Invoke(sp, third))));
}