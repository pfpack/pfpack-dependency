#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public Dependency<T1, T2, T3, T4, T5, T6, T7, T8> With<T3, T4, T5, T6, T7, T8>(
            Dependency<T3, T4, T5, T6, T7, T8> other)
            =>
            InnerWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T1, T2, T3, T4, T5, T6, T7, T8> InnerWith<T3, T4, T5, T6, T7, T8>(
            Dependency<T3, T4, T5, T6, T7, T8> other)
            =>
            new(
                firstResolver,
                secondResolver,
                other.ToFirstResolver(),
                other.ToSecondResolver(),
                other.ToThirdResolver(),
                other.ToFourthResolver(),
                other.ToFifthResolver(),
                other.ToSixthResolver());
    }
}