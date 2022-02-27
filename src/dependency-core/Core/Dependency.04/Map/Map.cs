using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4>
{
    public Dependency<TResult1, TResult2, TResult3, TResult4> Map<TResult1, TResult2, TResult3, TResult4>(
        Func<T1, TResult1> mapFirst,
        Func<T2, TResult2> mapSecond,
        Func<T3, TResult3> mapThird,
        Func<T4, TResult4> mapFourth)
        =>
        InnerMap(
            mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
            mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
            mapThird ?? throw new ArgumentNullException(nameof(mapThird)),
            mapFourth ?? throw new ArgumentNullException(nameof(mapFourth)));

    private Dependency<TResult1, TResult2, TResult3, TResult4> InnerMap<TResult1, TResult2, TResult3, TResult4>(
        Func<T1, TResult1> mapFirst,
        Func<T2, TResult2> mapSecond,
        Func<T3, TResult3> mapThird,
        Func<T4, TResult4> mapFourth)
        =>
        new(
            new(sp => sp.InternalPipe(firstResolver.Invoke).InternalPipe(mapFirst)),
            new(sp => sp.InternalPipe(secondResolver.Invoke).InternalPipe(mapSecond)),
            new(sp => sp.InternalPipe(thirdResolver.Invoke).InternalPipe(mapThird)),
            new(sp => sp.InternalPipe(fourthResolver.Invoke).InternalPipe(mapFourth)));
}