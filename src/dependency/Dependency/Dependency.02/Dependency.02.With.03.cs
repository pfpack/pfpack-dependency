#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public Dependency<T1, T2, T3> With<T3>(
            Dependency<T3> other)
            =>
            InternalWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T1, T2, T3> InternalWith<T3>(
            Dependency<T3> other)
            =>
            Dependency<T1, T2, T3>.InternalCreate(
                firstResolver,
                secondResolver,
                other.InternalResolver);
    }
}