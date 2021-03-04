#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public Dependency<T1, T2, T3, T4, T5> With<T3, T4, T5>(
            Dependency<T3, T4, T5> other)
            =>
            InternalWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T1, T2, T3, T4, T5> InternalWith<T3, T4, T5>(
            Dependency<T3, T4, T5> other)
            =>
            new(
                firstResolver,
                secondResolver,
                other.InternalFirstResolver,
                other.InternalSecondResolver,
                other.InternalThirdResolver);
    }
}