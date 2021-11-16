using System;

namespace PrimeFuncPack;

public sealed partial class Dependency<T1, T2, T3, T4>
{
    private readonly Func<IServiceProvider, T1> firstResolver;

    private readonly Func<IServiceProvider, T2> secondResolver;

    private readonly Func<IServiceProvider, T3> thirdResolver;

    private readonly Func<IServiceProvider, T4> fourthResolver;

    internal Dependency(
        Func<IServiceProvider, T1> firstResolver,
        Func<IServiceProvider, T2> secondResolver,
        Func<IServiceProvider, T3> thirdResolver,
        Func<IServiceProvider, T4> fourthResolver)
    {
        this.firstResolver = firstResolver;
        this.secondResolver = secondResolver;
        this.thirdResolver = thirdResolver;
        this.fourthResolver = fourthResolver;
    }
}