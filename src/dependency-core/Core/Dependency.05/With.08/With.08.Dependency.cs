using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> With<T6, T7, TRest>(
        Dependency<T6, T7, TRest> other)
        =>
        InnerWith(
            other ?? throw new ArgumentNullException(nameof(other)));

    private Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> InnerWith<T6, T7, TRest>(
        Dependency<T6, T7, TRest> other)
        =>
        new(
            firstResolver,
            secondResolver,
            thirdResolver,
            fourthResolver,
            fifthResolver,
            other.InternalToFirstResolver(),
            other.InternalToSecondResolver(),
            other.InternalToThirdResolver());
}