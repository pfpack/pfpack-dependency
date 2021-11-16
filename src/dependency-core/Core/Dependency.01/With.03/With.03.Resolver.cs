using System;

namespace PrimeFuncPack;

partial class Dependency<T>
{
    public Dependency<T, T2, T3> With<T2, T3>(
        Func<IServiceProvider, T2> second,
        Func<IServiceProvider, T3> third)
        =>
        InnerWith(
            second ?? throw new ArgumentNullException(nameof(second)),
            third ?? throw new ArgumentNullException(nameof(third)));

    private Dependency<T, T2, T3> InnerWith<T2, T3>(
        Func<IServiceProvider, T2> secondResolver,
        Func<IServiceProvider, T3> thirdResolver)
        =>
        new(
            resolver, secondResolver, thirdResolver);
}