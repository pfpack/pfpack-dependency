using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3>
{
    public Dependency<T1, T2, T3, T4, T5> With<T4, T5>(
        Func<T4> fourth,
        Func<T5> fifth)
        =>
        InnerWith(
            fourth ?? throw new ArgumentNullException(nameof(fourth)),
            fifth ?? throw new ArgumentNullException(nameof(fifth)));

    private Dependency<T1, T2, T3, T4, T5> InnerWith<T4, T5>(
        Func<T4> fourth,
        Func<T5> fifth)
        =>
        new(
            firstResolver,
            secondResolver,
            thirdResolver,
            fourth,
            fifth);
}