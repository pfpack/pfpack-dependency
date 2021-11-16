using System;

namespace PrimeFuncPack;

partial class Dependency<T>
{
    public Dependency<T, T2, T3> With<T2, T3>(
        Dependency<T2, T3> other)
        =>
        InnerWith(
            other ?? throw new ArgumentNullException(nameof(other)));

    private Dependency<T, T2, T3> InnerWith<T2, T3>(
        Dependency<T2, T3> other)
        =>
        new(
            resolver,
            other.InternalToFirstResolver(),
            other.InternalToSecondResolver());
}