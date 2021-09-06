#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public Dependency<T1, T2, T3> With<T3>(
            Dependency<T3> other)
            =>
            InnerWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T1, T2, T3> InnerWith<T3>(
            Dependency<T3> other)
            =>
            new(
                firstResolver,
                secondResolver,
                other.ToResolver());
    }
}