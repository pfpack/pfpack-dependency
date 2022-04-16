using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5, T6, T7, TRest>
{
    public Dependency<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResultRest> Map<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResultRest>(
        Func<T1, TResult1> mapFirst,
        Func<T2, TResult2> mapSecond,
        Func<T3, TResult3> mapThird,
        Func<T4, TResult4> mapFourth,
        Func<T5, TResult5> mapFifth,
        Func<T6, TResult6> mapSixth,
        Func<T7, TResult7> mapSeventh,
        Func<TRest, TResultRest> mapRest)
        =>
        InnerMap(
            mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
            mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
            mapThird ?? throw new ArgumentNullException(nameof(mapThird)),
            mapFourth ?? throw new ArgumentNullException(nameof(mapFourth)),
            mapFifth ?? throw new ArgumentNullException(nameof(mapFifth)),
            mapSixth ?? throw new ArgumentNullException(nameof(mapSixth)),
            mapSeventh ?? throw new ArgumentNullException(nameof(mapSeventh)),
            mapRest ?? throw new ArgumentNullException(nameof(mapRest)));

    private Dependency<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResultRest> InnerMap<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResultRest>(
        Func<T1, TResult1> mapFirst,
        Func<T2, TResult2> mapSecond,
        Func<T3, TResult3> mapThird,
        Func<T4, TResult4> mapFourth,
        Func<T5, TResult5> mapFifth,
        Func<T6, TResult6> mapSixth,
        Func<T7, TResult7> mapSeventh,
        Func<TRest, TResultRest> mapRest)
        =>
        new(
            new(sp => sp.InternalResolveThenMap(firstResolver.Invoke, mapFirst)),
            new(sp => sp.InternalResolveThenMap(secondResolver.Invoke, mapSecond)),
            new(sp => sp.InternalResolveThenMap(thirdResolver.Invoke, mapThird)),
            new(sp => sp.InternalResolveThenMap(fourthResolver.Invoke, mapFourth)),
            new(sp => sp.InternalResolveThenMap(fifthResolver.Invoke, mapFifth)),
            new(sp => sp.InternalResolveThenMap(sixthResolver.Invoke, mapSixth)),
            new(sp => sp.InternalResolveThenMap(seventhResolver.Invoke, mapSeventh)),
            new(sp => sp.InternalResolveThenMap(restResolver.Invoke, mapRest)));
}