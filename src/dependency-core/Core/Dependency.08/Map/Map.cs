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
            sp => sp.InternalPipe(firstResolver).InternalPipe(mapFirst),
            sp => sp.InternalPipe(secondResolver).InternalPipe(mapSecond),
            sp => sp.InternalPipe(thirdResolver).InternalPipe(mapThird),
            sp => sp.InternalPipe(fourthResolver).InternalPipe(mapFourth),
            sp => sp.InternalPipe(fifthResolver).InternalPipe(mapFifth),
            sp => sp.InternalPipe(sixthResolver).InternalPipe(mapSixth),
            sp => sp.InternalPipe(seventhResolver).InternalPipe(mapSeventh),
            sp => sp.InternalPipe(restResolver).InternalPipe(mapRest));
}