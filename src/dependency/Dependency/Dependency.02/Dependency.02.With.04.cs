#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public Dependency<T1, T2, T3, T4> With<T3, T4>(
            Dependency<T3, T4> other)
            =>
            InternalWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T1, T2, T3, T4> InternalWith<T3, T4>(
            Dependency<T3, T4> other)
            =>
            Dependency<T1, T2, T3, T4>.InternalCreate(
                firstResolver,
                secondResolver,
                other.InternalFirstResolver,
                other.InternalSecondResolver);
    }
}