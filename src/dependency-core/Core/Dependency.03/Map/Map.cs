#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public Dependency<TResult1, TResult2, TResult3> Map<TResult1, TResult2, TResult3>(
            Func<T1, TResult1> mapFirst,
            Func<T2, TResult2> mapSecond,
            Func<T3, TResult3> mapThird)
            =>
            InnerMap(
                mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
                mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
                mapThird ?? throw new ArgumentNullException(nameof(mapThird)));

        private Dependency<TResult1, TResult2, TResult3> InnerMap<TResult1, TResult2, TResult3>(
            Func<T1, TResult1> mapFirst,
            Func<T2, TResult2> mapSecond,
            Func<T3, TResult3> mapThird)
            =>
            new(
                sp => sp.Pipe(firstResolver).Pipe(mapFirst),
                sp => sp.Pipe(secondResolver).Pipe(mapSecond),
                sp => sp.Pipe(thirdResolver).Pipe(mapThird));
    }
}