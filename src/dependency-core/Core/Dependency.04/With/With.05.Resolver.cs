#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        public Dependency<T1, T2, T3, T4, T5> With<T5>(
            Func<IServiceProvider, T5> fifth)
            =>
            InternalWith(
                fifth ?? throw new ArgumentNullException(nameof(fifth)));

        private Dependency<T1, T2, T3, T4, T5> InternalWith<T5>(
            Func<IServiceProvider, T5> fifthResolver)
            =>
            new(
                firstResolver, secondResolver, thirdResolver, fourthResolver, fifthResolver);
    }
}