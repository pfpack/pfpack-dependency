#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public Dependency<T1, T2, T3, T4, T5> With<T3, T4, T5>(
            Func<IServiceProvider, T3> third,
            Func<IServiceProvider, T4> fourth,
            Func<IServiceProvider, T5> fifth)
            =>
            InternalWith(
                third ?? throw new ArgumentNullException(nameof(third)),
                fourth ?? throw new ArgumentNullException(nameof(fourth)),
                fifth ?? throw new ArgumentNullException(nameof(fifth)));

        private Dependency<T1, T2, T3, T4, T5> InternalWith<T3, T4, T5>(
            Func<IServiceProvider, T3> thirdResolver,
            Func<IServiceProvider, T4> fourthResolver,
            Func<IServiceProvider, T5> fifthResolver)
            =>
            new(
                firstResolver, secondResolver, thirdResolver, fourthResolver, fifthResolver);
    }
}