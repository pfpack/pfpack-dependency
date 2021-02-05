#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5>
    {
        public Dependency<TR1, TR2, TR3, TR4, TR5> Map<TR1, TR2, TR3, TR4, TR5>(
            Func<IServiceProvider, T1, TR1> mapFirst,
            Func<IServiceProvider, T2, TR2> mapSecond,
            Func<IServiceProvider, T3, TR3> mapThird,
            Func<IServiceProvider, T4, TR4> mapFourth,
            Func<IServiceProvider, T5, TR5> mapFifth)
            =>
            InternalMap(
                mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
                mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
                mapThird ?? throw new ArgumentNullException(nameof(mapThird)),
                mapFourth ?? throw new ArgumentNullException(nameof(mapFourth)),
                mapFifth ?? throw new ArgumentNullException(nameof(mapFifth)));

        private Dependency<TR1, TR2, TR3, TR4, TR5> InternalMap<TR1, TR2, TR3, TR4, TR5>(
            Func<IServiceProvider, T1, TR1> mapFirst,
            Func<IServiceProvider, T2, TR2> mapSecond,
            Func<IServiceProvider, T3, TR3> mapThird,
            Func<IServiceProvider, T4, TR4> mapFourth,
            Func<IServiceProvider, T5, TR5> mapFifth)
            =>
            new(
                sp => sp.Pipe(firstResolver).Pipe(first => mapFirst.Invoke(sp, first)),
                sp => sp.Pipe(secondResolver).Pipe(second => mapSecond.Invoke(sp, second)),
                sp => sp.Pipe(thirdResolver).Pipe(third => mapThird.Invoke(sp, third)),
                sp => sp.Pipe(fourthResolver).Pipe(fourth => mapFourth.Invoke(sp, fourth)),
                sp => sp.Pipe(fifthResolver).Pipe(fifth => mapFifth.Invoke(sp, fifth)));
    }
}