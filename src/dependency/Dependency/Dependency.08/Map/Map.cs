#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        public Dependency<TR1, TR2, TR3, TR4, TR5, TR6, TR7, TR8> Map<TR1, TR2, TR3, TR4, TR5, TR6, TR7, TR8>(
            Func<T1, TR1> mapFirst,
            Func<T2, TR2> mapSecond,
            Func<T3, TR3> mapThird,
            Func<T4, TR4> mapFourth,
            Func<T5, TR5> mapFifth,
            Func<T6, TR6> mapSixth,
            Func<T7, TR7> mapSeventh,
            Func<T8, TR8> mapEighth)
            =>
            throw new NotImplementedException();

        private Dependency<TR1, TR2, TR3, TR4, TR5, TR6, TR7, TR8> InternalMap<TR1, TR2, TR3, TR4, TR5, TR6, TR7, TR8>(
            Func<T1, TR1> mapFirst,
            Func<T2, TR2> mapSecond,
            Func<T3, TR3> mapThird,
            Func<T4, TR4> mapFourth,
            Func<T5, TR5> mapFifth,
            Func<T6, TR6> mapSixth,
            Func<T7, TR7> mapSeventh,
            Func<T8, TR8> mapEighth)
            =>
            new(
                sp => sp.Pipe(firstResolver).Pipe(mapFirst),
                sp => sp.Pipe(secondResolver).Pipe(mapSecond),
                sp => sp.Pipe(thirdResolver).Pipe(mapThird),
                sp => sp.Pipe(fourthResolver).Pipe(mapFourth),
                sp => sp.Pipe(fifthResolver).Pipe(mapFifth),
                sp => sp.Pipe(sixthResolver).Pipe(mapSixth),
                sp => sp.Pipe(seventhResolver).Pipe(mapSeventh),
                sp => sp.Pipe(eighthResolver).Pipe(mapEighth));
    }
}