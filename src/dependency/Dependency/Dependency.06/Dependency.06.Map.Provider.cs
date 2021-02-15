#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6>
    {
        public Dependency<TR1, TR2, TR3, TR4, TR5, TR6> Map<TR1, TR2, TR3, TR4, TR5, TR6>(
            Func<IServiceProvider, T1, TR1> mapFirst,
            Func<IServiceProvider, T2, TR2> mapSecond,
            Func<IServiceProvider, T3, TR3> mapThird,
            Func<IServiceProvider, T4, TR4> mapFourth,
            Func<IServiceProvider, T5, TR5> mapFifth,
            Func<IServiceProvider, T6, TR6> mapSixth)
            =>
            throw new NotImplementedException();

        private Dependency<TR1, TR2, TR3, TR4, TR5, TR6> InternalMap<TR1, TR2, TR3, TR4, TR5, TR6>(
            Func<IServiceProvider, T1, TR1> mapFirst,
            Func<IServiceProvider, T2, TR2> mapSecond,
            Func<IServiceProvider, T3, TR3> mapThird,
            Func<IServiceProvider, T4, TR4> mapFourth,
            Func<IServiceProvider, T5, TR5> mapFifth,
            Func<IServiceProvider, T6, TR6> mapSixth)
            =>
            new(
                sp => sp.Pipe(firstResolver).Pipe(first => mapFirst.Invoke(sp, first)),
                sp => sp.Pipe(secondResolver).Pipe(second => mapSecond.Invoke(sp, second)),
                sp => sp.Pipe(thirdResolver).Pipe(third => mapThird.Invoke(sp, third)),
                sp => sp.Pipe(fourthResolver).Pipe(fourth => mapFourth.Invoke(sp, fourth)),
                sp => sp.Pipe(fifthResolver).Pipe(fifth => mapFifth.Invoke(sp, fifth)),
                sp => sp.Pipe(sixthResolver).Pipe(sixth => mapSixth.Invoke(sp, sixth)));
    }
}