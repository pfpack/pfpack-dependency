#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6>
    {
        public Dependency<T1, T2, T3, T4, T5, T6, T7> With<T7>(
            Func<IServiceProvider, T7> seventh)
            =>
            InternalWith(
                seventh ?? throw new ArgumentNullException(nameof(seventh)));

        private Dependency<T1, T2, T3, T4, T5, T6, T7> InternalWith<T7>(
            Func<IServiceProvider, T7> seventhResolver)
            =>
            new(
                firstResolver, secondResolver, thirdResolver, fourthResolver, fifthResolver, sixthResolver, seventhResolver);
    }
}