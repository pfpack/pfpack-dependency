#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Dependency<T, T2, T3> With<T2, T3>(
            Dependency<T2, T3> other)
            =>
            InternalWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T, T2, T3> InternalWith<T2, T3>(
            Dependency<T2, T3> other)
            =>
            Dependency<T, T2, T3>.InternalCreate(
                resolver,
                other.InternalFirstResolver,
                other.InternalSecondResolver);
    }
}