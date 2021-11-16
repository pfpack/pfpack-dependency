using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> With<T4, T5, T6, T7, TRest>(
        Dependency<T4, T5, T6, T7, TRest> other)
        =>
        InnerWith(
            other ?? throw new ArgumentNullException(nameof(other)));

    private Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> InnerWith<T4, T5, T6, T7, TRest>(
        Dependency<T4, T5, T6, T7, TRest> other)
        =>
        new(
            firstResolver,
            secondResolver,
            thirdResolver,
            other.InternalToFirstResolver(),
            other.InternalToSecondResolver(),
            other.InternalToThirdResolver(),
            other.InternalToFourthResolver(),
            other.InternalToFifthResolver());
}