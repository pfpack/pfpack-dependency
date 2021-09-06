#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public Dependency<T1, T2, T3, T4> With<T4>(
            Dependency<T4> other)
            =>
            InnerWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T1, T2, T3, T4> InnerWith<T4>(
            Dependency<T4> other)
            =>
            new(
                firstResolver,
                secondResolver,
                thirdResolver,
                other.ToResolver());
    }
}