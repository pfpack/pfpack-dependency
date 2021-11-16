using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5>
{
    public Dependency<TResult1, TResult2, TResult3, TResult4, TResult5> Map<TResult1, TResult2, TResult3, TResult4, TResult5>(
        Func<T1, TResult1> mapFirst,
        Func<T2, TResult2> mapSecond,
        Func<T3, TResult3> mapThird,
        Func<T4, TResult4> mapFourth,
        Func<T5, TResult5> mapFifth)
        =>
        InnerMap(
            mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
            mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
            mapThird ?? throw new ArgumentNullException(nameof(mapThird)),
            mapFourth ?? throw new ArgumentNullException(nameof(mapFourth)),
            mapFifth ?? throw new ArgumentNullException(nameof(mapFifth)));

    private Dependency<TResult1, TResult2, TResult3, TResult4, TResult5> InnerMap<TResult1, TResult2, TResult3, TResult4, TResult5>(
        Func<T1, TResult1> mapFirst,
        Func<T2, TResult2> mapSecond,
        Func<T3, TResult3> mapThird,
        Func<T4, TResult4> mapFourth,
        Func<T5, TResult5> mapFifth)
        =>
        new(
            sp => sp.InternalPipe(firstResolver).InternalPipe(mapFirst),
            sp => sp.InternalPipe(secondResolver).InternalPipe(mapSecond),
            sp => sp.InternalPipe(thirdResolver).InternalPipe(mapThird),
            sp => sp.InternalPipe(fourthResolver).InternalPipe(mapFourth),
            sp => sp.InternalPipe(fifthResolver).InternalPipe(mapFifth));
}