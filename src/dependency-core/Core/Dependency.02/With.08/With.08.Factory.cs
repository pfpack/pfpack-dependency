using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> With<T3, T4, T5, T6, T7, TRest>(
        Func<T3> third,
        Func<T4> fourth,
        Func<T5> fifth,
        Func<T6> sixth,
        Func<T7> seventh,
        Func<TRest> rest)
        =>
        InnerWith(
            third ?? throw new ArgumentNullException(nameof(third)),
            fourth ?? throw new ArgumentNullException(nameof(fourth)),
            fifth ?? throw new ArgumentNullException(nameof(fifth)),
            sixth ?? throw new ArgumentNullException(nameof(sixth)),
            seventh ?? throw new ArgumentNullException(nameof(seventh)),
            rest ?? throw new ArgumentNullException(nameof(rest)));

    private Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> InnerWith<T3, T4, T5, T6, T7, TRest>(
        Func<T3> third,
        Func<T4> fourth,
        Func<T5> fifth,
        Func<T6> sixth,
        Func<T7> seventh,
        Func<TRest> rest)
        =>
        new(
            firstResolver,
            secondResolver,
            _ => third.Invoke(),
            _ => fourth.Invoke(),
            _ => fifth.Invoke(),
            _ => sixth.Invoke(),
            _ => seventh.Invoke(),
            _ => rest.Invoke());
}