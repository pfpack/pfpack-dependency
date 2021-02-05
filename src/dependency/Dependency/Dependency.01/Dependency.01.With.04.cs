#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Dependency<T, T2, T3, T4> With<T2, T3, T4>(
            Dependency<T2, T3, T4> other)
            =>
            InternalWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T, T2, T3, T4> InternalWith<T2, T3, T4>(
            Dependency<T2, T3, T4> other)
            =>
            new(
                resolver,
                other.InternalFirstResolver,
                other.InternalSecondResolver,
                other.InternalThirdResolver);
    }
}