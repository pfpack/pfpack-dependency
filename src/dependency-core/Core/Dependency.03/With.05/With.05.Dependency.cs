#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public Dependency<T1, T2, T3, T4, T5> With<T4, T5>(
            Dependency<T4, T5> other)
            =>
            InnerWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T1, T2, T3, T4, T5> InnerWith<T4, T5>(
            Dependency<T4, T5> other)
            =>
            new(
                firstResolver,
                secondResolver,
                thirdResolver,
                other.InternalToFirstResolver(),
                other.InternalToSecondResolver());
    }
}