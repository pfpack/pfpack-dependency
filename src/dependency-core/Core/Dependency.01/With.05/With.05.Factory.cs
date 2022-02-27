using System;

namespace PrimeFuncPack;

partial class Dependency<T>
{
    public Dependency<T, T2, T3, T4, T5> With<T2, T3, T4, T5>(
        Func<T2> second,
        Func<T3> third,
        Func<T4> fourth,
        Func<T5> fifth)
        =>
        InnerWith(
            second ?? throw new ArgumentNullException(nameof(second)),
            third ?? throw new ArgumentNullException(nameof(third)),
            fourth ?? throw new ArgumentNullException(nameof(fourth)),
            fifth ?? throw new ArgumentNullException(nameof(fifth)));

    private Dependency<T, T2, T3, T4, T5> InnerWith<T2, T3, T4, T5>(
        Func<T2> second,
        Func<T3> third,
        Func<T4> fourth,
        Func<T5> fifth)
        =>
        new(
            resolver,
            second,
            third,
            fourth,
            fifth);
}