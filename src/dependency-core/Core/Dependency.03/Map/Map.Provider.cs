#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public Dependency<TResult1, TResult2, TResult3> Map<TResult1, TResult2, TResult3>(
            Func<IServiceProvider, T1, TResult1> mapFirst,
            Func<IServiceProvider, T2, TResult2> mapSecond,
            Func<IServiceProvider, T3, TResult3> mapThird)
            =>
            InnerMap(
                mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
                mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
                mapThird ?? throw new ArgumentNullException(nameof(mapThird)));

        private Dependency<TResult1, TResult2, TResult3> InnerMap<TResult1, TResult2, TResult3>(
            Func<IServiceProvider, T1, TResult1> mapFirst,
            Func<IServiceProvider, T2, TResult2> mapSecond,
            Func<IServiceProvider, T3, TResult3> mapThird)
            =>
            new(
                sp => sp.InternalPipe(firstResolver).InternalPipe(first => mapFirst.Invoke(sp, first)),
                sp => sp.InternalPipe(secondResolver).InternalPipe(second => mapSecond.Invoke(sp, second)),
                sp => sp.InternalPipe(thirdResolver).InternalPipe(third => mapThird.Invoke(sp, third)));
    }
}