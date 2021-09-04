#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        public Dependency<T1, T2, T3, T4, T5, T6, T7, T8> With<T5, T6, T7, T8>(
            Func<IServiceProvider, T5> fifth,
            Func<IServiceProvider, T6> sixth,
            Func<IServiceProvider, T7> seventh,
            Func<IServiceProvider, T8> rest)
            =>
            InnerWith(
                fifth ?? throw new ArgumentNullException(nameof(fifth)),
                sixth ?? throw new ArgumentNullException(nameof(sixth)),
                seventh ?? throw new ArgumentNullException(nameof(seventh)),
                rest ?? throw new ArgumentNullException(nameof(rest)));

        private Dependency<T1, T2, T3, T4, T5, T6, T7, T8> InnerWith<T5, T6, T7, T8>(
            Func<IServiceProvider, T5> fifthResolver,
            Func<IServiceProvider, T6> sixthResolver,
            Func<IServiceProvider, T7> seventhResolver,
            Func<IServiceProvider, T8> restResolver)
            =>
            new(
                firstResolver, secondResolver, thirdResolver, fourthResolver, fifthResolver, sixthResolver, seventhResolver, restResolver);
    }
}