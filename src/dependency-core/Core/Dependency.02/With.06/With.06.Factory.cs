using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    public Dependency<T1, T2, T3, T4, T5, T6> With<T3, T4, T5, T6>(
        Func<T3> third,
        Func<T4> fourth,
        Func<T5> fifth,
        Func<T6> sixth)
        =>
        InnerWith(
            third ?? throw new ArgumentNullException(nameof(third)),
            fourth ?? throw new ArgumentNullException(nameof(fourth)),
            fifth ?? throw new ArgumentNullException(nameof(fifth)),
            sixth ?? throw new ArgumentNullException(nameof(sixth)));

    private Dependency<T1, T2, T3, T4, T5, T6> InnerWith<T3, T4, T5, T6>(
        Func<T3> third,
        Func<T4> fourth,
        Func<T5> fifth,
        Func<T6> sixth)
        =>
        new(
            firstResolver,
            secondResolver,
            _ => third.Invoke(),
            _ => fourth.Invoke(),
            _ => fifth.Invoke(),
            _ => sixth.Invoke());
}