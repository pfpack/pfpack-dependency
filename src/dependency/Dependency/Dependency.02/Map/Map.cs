#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public Dependency<TResult1, TResult2> Map<TResult1, TResult2>(
            Func<T1, TResult1> mapFirst,
            Func<T2, TResult2> mapSecond)
            =>
            InternalMap(
                mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
                mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)));

        private Dependency<TResult1, TResult2> InternalMap<TResult1, TResult2>(
            Func<T1, TResult1> mapFirst,
            Func<T2, TResult2> mapSecond)
            =>
            new(
                sp => sp.Pipe(firstResolver).Pipe(mapFirst),
                sp => sp.Pipe(secondResolver).Pipe(mapSecond));
    }
}