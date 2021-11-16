using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    public Dependency<T1, T2, T3, T4> With<T3, T4>(
        Dependency<T3, T4> other)
        =>
        InnerWith(
            other ?? throw new ArgumentNullException(nameof(other)));

    private Dependency<T1, T2, T3, T4> InnerWith<T3, T4>(
        Dependency<T3, T4> other)
        =>
        new(
            firstResolver,
            secondResolver,
            other.InternalToFirstResolver(),
            other.InternalToSecondResolver());
}