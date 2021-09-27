#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Dependency<T, T2, T3, T4, T5, T6, T7> With<T2, T3, T4, T5, T6, T7>(
            Dependency<T2, T3, T4, T5, T6, T7> other)
            =>
            InnerWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T, T2, T3, T4, T5, T6, T7> InnerWith<T2, T3, T4, T5, T6, T7>(
            Dependency<T2, T3, T4, T5, T6, T7> other)
            =>
            new(
                resolver,
                other.InternalToFirstResolver(),
                other.InternalToSecondResolver(),
                other.InternalToThirdResolver(),
                other.InternalToFourthResolver(),
                other.InternalToFifthResolver(),
                other.InternalToSixthResolver());
    }
}