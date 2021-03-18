#nullable enable

using System;

namespace PrimeFuncPack
{
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
            InternalMap(
                mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
                mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
                mapThird ?? throw new ArgumentNullException(nameof(mapThird)),
                mapFourth ?? throw new ArgumentNullException(nameof(mapFourth)),
                mapFifth ?? throw new ArgumentNullException(nameof(mapFifth)),
                mapSixth ?? throw new ArgumentNullException(nameof(mapSixth)),
                mapSeventh ?? throw new ArgumentNullException(nameof(mapSeventh)),
                mapRest ?? throw new ArgumentNullException(nameof(mapRest)));

        private Dependency<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResultRest> InternalMap<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResultRest>(
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
                sp => sp.Pipe(firstResolver).Pipe(first => mapFirst.Invoke(sp, first)),
                sp => sp.Pipe(secondResolver).Pipe(second => mapSecond.Invoke(sp, second)),
                sp => sp.Pipe(thirdResolver).Pipe(third => mapThird.Invoke(sp, third)),
                sp => sp.Pipe(fourthResolver).Pipe(fourth => mapFourth.Invoke(sp, fourth)),
                sp => sp.Pipe(fifthResolver).Pipe(fifth => mapFifth.Invoke(sp, fifth)),
                sp => sp.Pipe(sixthResolver).Pipe(sixth => mapSixth.Invoke(sp, sixth)),
                sp => sp.Pipe(seventhResolver).Pipe(seventh => mapSeventh.Invoke(sp, seventh)),
                sp => sp.Pipe(restResolver).Pipe(rest => mapRest.Invoke(sp, rest)));
    }
}