using System;

namespace PrimeFuncPack;

partial class Dependency<T>
{
    public Dependency<T, T2, T3, T4, T5, T6, T7, TRest> With<T2, T3, T4, T5, T6, T7, TRest>(
        Dependency<T2, T3, T4, T5, T6, T7, TRest> other)
        =>
        InnerWith(
            other ?? throw new ArgumentNullException(nameof(other)));

    private Dependency<T, T2, T3, T4, T5, T6, T7, TRest> InnerWith<T2, T3, T4, T5, T6, T7, TRest>(
        Dependency<T2, T3, T4, T5, T6, T7, TRest> other)
        =>
        new(
            resolver,
            other.InternalToFirstResolver(),
            other.InternalToSecondResolver(),
            other.InternalToThirdResolver(),
            other.InternalToFourthResolver(),
            other.InternalToFifthResolver(),
            other.InternalToSixthResolver(),
            other.InternalToSeventhResolver());
}