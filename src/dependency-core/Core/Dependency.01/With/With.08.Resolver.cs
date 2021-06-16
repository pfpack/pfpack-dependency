#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Dependency<T, T2, T3, T4, T5, T6, T7, T8> With<T2, T3, T4, T5, T6, T7, T8>(
            Func<IServiceProvider, T2> second,
            Func<IServiceProvider, T3> third,
            Func<IServiceProvider, T4> fourth,
            Func<IServiceProvider, T5> fifth,
            Func<IServiceProvider, T6> sixth,
            Func<IServiceProvider, T7> seventh,
            Func<IServiceProvider, T8> rest)
            =>
            InternalWith(
                second ?? throw new ArgumentNullException(nameof(second)),
                third ?? throw new ArgumentNullException(nameof(third)),
                fourth ?? throw new ArgumentNullException(nameof(fourth)),
                fifth ?? throw new ArgumentNullException(nameof(fifth)),
                sixth ?? throw new ArgumentNullException(nameof(sixth)),
                seventh ?? throw new ArgumentNullException(nameof(seventh)),
                rest ?? throw new ArgumentNullException(nameof(rest)));

        private Dependency<T, T2, T3, T4, T5, T6, T7, T8> InternalWith<T2, T3, T4, T5, T6, T7, T8>(
            Func<IServiceProvider, T2> secondResolver,
            Func<IServiceProvider, T3> thirdResolver,
            Func<IServiceProvider, T4> fourthResolver,
            Func<IServiceProvider, T5> fifthResolver,
            Func<IServiceProvider, T6> sixthResolver,
            Func<IServiceProvider, T7> seventhResolver,
            Func<IServiceProvider, T8> restResolver)
            =>
            new(
                resolver, secondResolver, thirdResolver, fourthResolver, fifthResolver, sixthResolver, seventhResolver, restResolver);
    }
}