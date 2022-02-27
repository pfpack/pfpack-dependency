using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5, T6, T7, TRest>
{
    public Dependency<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResultRest> Map<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResultRest>(
        Func<IServiceProvider, T1, TResult1> mapFirst,
        Func<IServiceProvider, T2, TResult2> mapSecond,
        Func<IServiceProvider, T3, TResult3> mapThird,
        Func<IServiceProvider, T4, TResult4> mapFourth,
        Func<IServiceProvider, T5, TResult5> mapFifth,
        Func<IServiceProvider, T6, TResult6> mapSixth,
        Func<IServiceProvider, T7, TResult7> mapSeventh,
        Func<IServiceProvider, TRest, TResultRest> mapRest)
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
        Func<IServiceProvider, T1, TResult1> mapFirst,
        Func<IServiceProvider, T2, TResult2> mapSecond,
        Func<IServiceProvider, T3, TResult3> mapThird,
        Func<IServiceProvider, T4, TResult4> mapFourth,
        Func<IServiceProvider, T5, TResult5> mapFifth,
        Func<IServiceProvider, T6, TResult6> mapSixth,
        Func<IServiceProvider, T7, TResult7> mapSeventh,
        Func<IServiceProvider, TRest, TResultRest> mapRest)
        =>
        new(
            new(sp => sp.InternalPipe(firstResolver.Invoke).InternalPipe(first => mapFirst.Invoke(sp, first))),
            new(sp => sp.InternalPipe(secondResolver.Invoke).InternalPipe(second => mapSecond.Invoke(sp, second))),
            new(sp => sp.InternalPipe(thirdResolver.Invoke).InternalPipe(third => mapThird.Invoke(sp, third))),
            new(sp => sp.InternalPipe(fourthResolver.Invoke).InternalPipe(fourth => mapFourth.Invoke(sp, fourth))),
            new(sp => sp.InternalPipe(fifthResolver.Invoke).InternalPipe(fifth => mapFifth.Invoke(sp, fifth))),
            new(sp => sp.InternalPipe(sixthResolver.Invoke).InternalPipe(sixth => mapSixth.Invoke(sp, sixth))),
            new(sp => sp.InternalPipe(seventhResolver.Invoke).InternalPipe(seventh => mapSeventh.Invoke(sp, seventh))),
            new(sp => sp.InternalPipe(restResolver.Invoke).InternalPipe(rest => mapRest.Invoke(sp, rest))));
}