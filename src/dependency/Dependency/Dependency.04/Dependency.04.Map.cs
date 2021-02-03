#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        public Dependency<TR1, TR2, TR3, TR4> Map<TR1, TR2, TR3, TR4>(
            Func<T1, TR1> mapFirst,
            Func<T2, TR2> mapSecond,
            Func<T3, TR3> mapThird,
            Func<T4, TR4> mapFourth)
            =>
            InternalMap(
                mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
                mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
                mapThird ?? throw new ArgumentNullException(nameof(mapThird)),
                mapFourth ?? throw new ArgumentNullException(nameof(mapFourth)));

        private Dependency<TR1, TR2, TR3, TR4> InternalMap<TR1, TR2, TR3, TR4>(
            Func<T1, TR1> mapFirst,
            Func<T2, TR2> mapSecond,
            Func<T3, TR3> mapThird,
            Func<T4, TR4> mapFourth)
            =>
            Dependency<TR1, TR2, TR3, TR4>.InternalCreate(
                sp => sp.Pipe(firstResolver).Pipe(mapFirst),
                sp => sp.Pipe(secondResolver).Pipe(mapSecond),
                sp => sp.Pipe(thirdResolver).Pipe(mapThird),
                sp => sp.Pipe(fourthResolver).Pipe(mapFourth));
    }
}