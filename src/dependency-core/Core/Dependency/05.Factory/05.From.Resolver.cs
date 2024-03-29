using System;

namespace PrimeFuncPack;

partial class Dependency
{
    public static Dependency<T1, T2, T3, T4, T5> From<T1, T2, T3, T4, T5>(
        Func<IServiceProvider, T1> first,
        Func<IServiceProvider, T2> second,
        Func<IServiceProvider, T3> third,
        Func<IServiceProvider, T4> fourth,
        Func<IServiceProvider, T5> fifth)
        =>
        new(
            first ?? throw new ArgumentNullException(nameof(first)),
            second ?? throw new ArgumentNullException(nameof(second)),
            third ?? throw new ArgumentNullException(nameof(third)),
            fourth ?? throw new ArgumentNullException(nameof(fourth)),
            fifth ?? throw new ArgumentNullException(nameof(fifth)));
}