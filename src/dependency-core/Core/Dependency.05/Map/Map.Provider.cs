#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5>
    {
        public Dependency<TResult1, TResult2, TResult3, TResult4, TResult5> Map<TResult1, TResult2, TResult3, TResult4, TResult5>(
            Func<IServiceProvider, T1, TResult1> mapFirst,
            Func<IServiceProvider, T2, TResult2> mapSecond,
            Func<IServiceProvider, T3, TResult3> mapThird,
            Func<IServiceProvider, T4, TResult4> mapFourth,
            Func<IServiceProvider, T5, TResult5> mapFifth)
            =>
            InnerMap(
                mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
                mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
                mapThird ?? throw new ArgumentNullException(nameof(mapThird)),
                mapFourth ?? throw new ArgumentNullException(nameof(mapFourth)),
                mapFifth ?? throw new ArgumentNullException(nameof(mapFifth)));

        private Dependency<TResult1, TResult2, TResult3, TResult4, TResult5> InnerMap<TResult1, TResult2, TResult3, TResult4, TResult5>(
            Func<IServiceProvider, T1, TResult1> mapFirst,
            Func<IServiceProvider, T2, TResult2> mapSecond,
            Func<IServiceProvider, T3, TResult3> mapThird,
            Func<IServiceProvider, T4, TResult4> mapFourth,
            Func<IServiceProvider, T5, TResult5> mapFifth)
            =>
            new(
                sp => sp.InternalPipe(firstResolver).InternalPipe(first => mapFirst.Invoke(sp, first)),
                sp => sp.InternalPipe(secondResolver).InternalPipe(second => mapSecond.Invoke(sp, second)),
                sp => sp.InternalPipe(thirdResolver).InternalPipe(third => mapThird.Invoke(sp, third)),
                sp => sp.InternalPipe(fourthResolver).InternalPipe(fourth => mapFourth.Invoke(sp, fourth)),
                sp => sp.InternalPipe(fifthResolver).InternalPipe(fifth => mapFifth.Invoke(sp, fifth)));
    }
}