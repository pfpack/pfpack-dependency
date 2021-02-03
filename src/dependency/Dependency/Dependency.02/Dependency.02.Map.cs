#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public Dependency<TR1, TR2> Map<TR1, TR2>(
            Func<T1, TR1> mapFirst,
            Func<T2, TR2> mapSecond)
            =>
            InternalMap(
                mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
                mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)));

        private Dependency<TR1, TR2> InternalMap<TR1, TR2>(
            Func<T1, TR1> mapFirst,
            Func<T2, TR2> mapSecond)
            =>
            Dependency<TR1, TR2>.InternalCreate(
                sp => sp.Pipe(firstResolver).Pipe(mapFirst),
                sp => sp.Pipe(secondResolver).Pipe(mapSecond));
    }
}