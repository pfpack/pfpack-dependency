using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> With<T5, T6, T7, TRest>(
        Dependency<T5, T6, T7, TRest> other)
        =>
        InnerWith(
            other ?? throw new ArgumentNullException(nameof(other)));

    private Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> InnerWith<T5, T6, T7, TRest>(
        Dependency<T5, T6, T7, TRest> other)
        =>
        new(
            firstResolver,
            secondResolver,
            thirdResolver,
            fourthResolver,
            other.InternalToFirstResolver(),
            other.InternalToSecondResolver(),
            other.InternalToThirdResolver(),
            other.InternalToFourthResolver());
}