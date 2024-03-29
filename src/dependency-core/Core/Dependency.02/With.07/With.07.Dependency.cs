using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7> With<T3, T4, T5, T6, T7>(
        Dependency<T3, T4, T5, T6, T7> other)
        =>
        InnerWith(
            other ?? throw new ArgumentNullException(nameof(other)));

    private Dependency<T1, T2, T3, T4, T5, T6, T7> InnerWith<T3, T4, T5, T6, T7>(
        Dependency<T3, T4, T5, T6, T7> other)
        =>
        new(
            firstResolver,
            secondResolver,
            other.InternalToFirstResolver(),
            other.InternalToSecondResolver(),
            other.InternalToThirdResolver(),
            other.InternalToFourthResolver(),
            other.InternalToFifthResolver());
}