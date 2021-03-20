#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        public Dependency<T1, T2, T3, T4, T5, T6, T7> With<T5, T6, T7>(
            Dependency<T5, T6, T7> other)
            =>
            InternalWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T1, T2, T3, T4, T5, T6, T7> InternalWith<T5, T6, T7>(
            Dependency<T5, T6, T7> other)
            =>
            new(
                firstResolver,
                secondResolver,
                thirdResolver,
                fourthResolver,
                other.ToFirstResolver(),
                other.ToSecondResolver(),
                other.ToThirdResolver());
    }
}