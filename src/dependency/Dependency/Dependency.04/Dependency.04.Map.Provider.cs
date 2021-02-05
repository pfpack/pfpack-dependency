#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        public Dependency<TR1, TR2, TR3, TR4> Map<TR1, TR2, TR3, TR4>(
            Func<IServiceProvider, T1, TR1> mapFirst,
            Func<IServiceProvider, T2, TR2> mapSecond,
            Func<IServiceProvider, T3, TR3> mapThird,
            Func<IServiceProvider, T4, TR4> mapFourth)
            =>
            InternalMap(
                mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
                mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
                mapThird ?? throw new ArgumentNullException(nameof(mapThird)),
                mapFourth ?? throw new ArgumentNullException(nameof(mapFourth)));

        private Dependency<TR1, TR2, TR3, TR4> InternalMap<TR1, TR2, TR3, TR4>(
            Func<IServiceProvider, T1, TR1> mapFirst,
            Func<IServiceProvider, T2, TR2> mapSecond,
            Func<IServiceProvider, T3, TR3> mapThird,
            Func<IServiceProvider, T4, TR4> mapFourth)
            =>
            new(
                sp => sp.Pipe(firstResolver).Pipe(first => mapFirst.Invoke(sp, first)),
                sp => sp.Pipe(secondResolver).Pipe(second => mapSecond.Invoke(sp, second)),
                sp => sp.Pipe(thirdResolver).Pipe(third => mapThird.Invoke(sp, third)),
                sp => sp.Pipe(fourthResolver).Pipe(fourth => mapFourth.Invoke(sp, fourth)));
    }
}