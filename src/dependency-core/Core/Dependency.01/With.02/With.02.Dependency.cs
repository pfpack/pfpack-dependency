using System;

namespace PrimeFuncPack;

partial class Dependency<T>
{
    public Dependency<T, T2> With<T2>(
        Dependency<T2> other)
        =>
        InnerWith(
            other ?? throw new ArgumentNullException(nameof(other)));

    private Dependency<T, T2> InnerWith<T2>(
        Dependency<T2> other)
        =>
        new(
            resolver,
            other.Resolve);
}