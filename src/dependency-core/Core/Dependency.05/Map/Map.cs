#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5>
    {
        public Dependency<TResult1, TResult2, TResult3, TResult4, TResult5> Map<TResult1, TResult2, TResult3, TResult4, TResult5>(
            Func<T1, TResult1> mapFirst,
            Func<T2, TResult2> mapSecond,
            Func<T3, TResult3> mapThird,
            Func<T4, TResult4> mapFourth,
            Func<T5, TResult5> mapFifth)
            =>
            InnerMap(
                mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
                mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
                mapThird ?? throw new ArgumentNullException(nameof(mapThird)),
                mapFourth ?? throw new ArgumentNullException(nameof(mapFourth)),
                mapFifth ?? throw new ArgumentNullException(nameof(mapFifth)));

        private Dependency<TResult1, TResult2, TResult3, TResult4, TResult5> InnerMap<TResult1, TResult2, TResult3, TResult4, TResult5>(
            Func<T1, TResult1> mapFirst,
            Func<T2, TResult2> mapSecond,
            Func<T3, TResult3> mapThird,
            Func<T4, TResult4> mapFourth,
            Func<T5, TResult5> mapFifth)
            =>
            new(
                sp => sp.Pipe(firstResolver).Pipe(mapFirst),
                sp => sp.Pipe(secondResolver).Pipe(mapSecond),
                sp => sp.Pipe(thirdResolver).Pipe(mapThird),
                sp => sp.Pipe(fourthResolver).Pipe(mapFourth),
                sp => sp.Pipe(fifthResolver).Pipe(mapFifth));
    }
}