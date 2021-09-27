#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Dependency<T, T2, T3, T4, T5> With<T2, T3, T4, T5>(
            Dependency<T2, T3, T4, T5> other)
            =>
            InnerWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T, T2, T3, T4, T5> InnerWith<T2, T3, T4, T5>(
            Dependency<T2, T3, T4, T5> other)
            =>
            new(
                resolver,
                other.InternalToFirstResolver(),
                other.InternalToSecondResolver(),
                other.InternalToThirdResolver(),
                other.InternalToFourthResolver());
    }
}