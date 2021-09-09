#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6>
    {
        public Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> With<T7, TRest>(
            Func<IServiceProvider, T7> seventh,
            Func<IServiceProvider, TRest> rest)
            =>
            InnerWith(
                seventh ?? throw new ArgumentNullException(nameof(seventh)),
                rest ?? throw new ArgumentNullException(nameof(rest)));

        private Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> InnerWith<T7, TRest>(
            Func<IServiceProvider, T7> seventhResolver,
            Func<IServiceProvider, TRest> restResolver)
            =>
            new(
                firstResolver, secondResolver, thirdResolver, fourthResolver, fifthResolver, sixthResolver, seventhResolver, restResolver);
    }
}