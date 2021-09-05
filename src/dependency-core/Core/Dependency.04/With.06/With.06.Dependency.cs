#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        public Dependency<T1, T2, T3, T4, T5, T6> With<T5, T6>(
            Dependency<T5, T6> other)
            =>
            InnerWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T1, T2, T3, T4, T5, T6> InnerWith<T5, T6>(
            Dependency<T5, T6> other)
            =>
            new(
                firstResolver,
                secondResolver,
                thirdResolver,
                fourthResolver,
                other.ToFirstResolver(),
                other.ToSecondResolver());
    }
}