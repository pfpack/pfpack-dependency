#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public Dependency<TR1, TR2, TR3> Map<TR1, TR2, TR3>(
            Func<IServiceProvider, T1, TR1> mapFirst,
            Func<IServiceProvider, T2, TR2> mapSecond,
            Func<IServiceProvider, T3, TR3> mapThird)
            =>
            InternalMap(
                mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
                mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
                mapThird ?? throw new ArgumentNullException(nameof(mapThird)));

        private Dependency<TR1, TR2, TR3> InternalMap<TR1, TR2, TR3>(
            Func<IServiceProvider, T1, TR1> mapFirst,
            Func<IServiceProvider, T2, TR2> mapSecond,
            Func<IServiceProvider, T3, TR3> mapThird)
            =>
            Dependency<TR1, TR2, TR3>.InternalCreate(
                sp => sp.Pipe(firstResolver).Pipe(first => mapFirst.Invoke(sp, first)),
                sp => sp.Pipe(secondResolver).Pipe(second => mapSecond.Invoke(sp, second)),
                sp => sp.Pipe(thirdResolver).Pipe(third => mapThird.Invoke(sp, third)));
    }
}