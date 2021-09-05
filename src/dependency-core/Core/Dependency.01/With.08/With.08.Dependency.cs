#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Dependency<T, T2, T3, T4, T5, T6, T7, T8> With<T2, T3, T4, T5, T6, T7, T8>(
            Dependency<T2, T3, T4, T5, T6, T7, T8> other)
            =>
            InnerWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T, T2, T3, T4, T5, T6, T7, T8> InnerWith<T2, T3, T4, T5, T6, T7, T8>(
            Dependency<T2, T3, T4, T5, T6, T7, T8> other)
            =>
            new(
                resolver,
                other.ToFirstResolver(),
                other.ToSecondResolver(),
                other.ToThirdResolver(),
                other.ToFourthResolver(),
                other.ToFifthResolver(),
                other.ToSixthResolver(),
                other.ToSeventhResolver());
    }
}