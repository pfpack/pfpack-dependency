using System;

namespace PrimeFuncPack;

partial class Dependency<T>
{
    public Dependency<T, T2> With<T2>(
        Func<IServiceProvider, T2> second)
        =>
        InnerWith(
            second ?? throw new ArgumentNullException(nameof(second)));

    private Dependency<T, T2> InnerWith<T2>(
        Func<IServiceProvider, T2> secondResolver)
        =>
        new(
            resolver, secondResolver);
}