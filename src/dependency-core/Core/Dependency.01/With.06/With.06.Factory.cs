using System;

namespace PrimeFuncPack;

partial class Dependency<T>
{
    public Dependency<T, T2, T3, T4, T5, T6> With<T2, T3, T4, T5, T6>(
        Func<T2> second,
        Func<T3> third,
        Func<T4> fourth,
        Func<T5> fifth,
        Func<T6> sixth)
        =>
        InnerWith(
            second ?? throw new ArgumentNullException(nameof(second)),
            third ?? throw new ArgumentNullException(nameof(third)),
            fourth ?? throw new ArgumentNullException(nameof(fourth)),
            fifth ?? throw new ArgumentNullException(nameof(fifth)),
            sixth ?? throw new ArgumentNullException(nameof(sixth)));

    private Dependency<T, T2, T3, T4, T5, T6> InnerWith<T2, T3, T4, T5, T6>(
        Func<T2> second,
        Func<T3> third,
        Func<T4> fourth,
        Func<T5> fifth,
        Func<T6> sixth)
        =>
        new(
            resolver,
            second,
            third,
            fourth,
            fifth,
            sixth);
}