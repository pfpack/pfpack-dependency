#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6>
    {
        public Dependency<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> Map<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(
            Func<T1, TResult1> mapFirst,
            Func<T2, TResult2> mapSecond,
            Func<T3, TResult3> mapThird,
            Func<T4, TResult4> mapFourth,
            Func<T5, TResult5> mapFifth,
            Func<T6, TResult6> mapSixth)
            =>
            InternalMap(
                mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
                mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
                mapThird ?? throw new ArgumentNullException(nameof(mapThird)),
                mapFourth ?? throw new ArgumentNullException(nameof(mapFourth)),
                mapFifth ?? throw new ArgumentNullException(nameof(mapFifth)),
                mapSixth ?? throw new ArgumentNullException(nameof(mapSixth)));

        private Dependency<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> InternalMap<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(
            Func<T1, TResult1> mapFirst,
            Func<T2, TResult2> mapSecond,
            Func<T3, TResult3> mapThird,
            Func<T4, TResult4> mapFourth,
            Func<T5, TResult5> mapFifth,
            Func<T6, TResult6> mapSixth)
            =>
            new(
                sp => sp.Pipe(firstResolver).Pipe(mapFirst),
                sp => sp.Pipe(secondResolver).Pipe(mapSecond),
                sp => sp.Pipe(thirdResolver).Pipe(mapThird),
                sp => sp.Pipe(fourthResolver).Pipe(mapFourth),
                sp => sp.Pipe(fifthResolver).Pipe(mapFifth),
                sp => sp.Pipe(sixthResolver).Pipe(mapSixth));
    }
}