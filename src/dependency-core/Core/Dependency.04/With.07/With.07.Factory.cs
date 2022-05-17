using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7> With<T5, T6, T7>(
        Func<T5> fifth,
        Func<T6> sixth,
        Func<T7> seventh)
        =>
        InnerWith(
            fifth ?? throw new ArgumentNullException(nameof(fifth)),
            sixth ?? throw new ArgumentNullException(nameof(sixth)),
            seventh ?? throw new ArgumentNullException(nameof(seventh)));

    private Dependency<T1, T2, T3, T4, T5, T6, T7> InnerWith<T5, T6, T7>(
        Func<T5> fifth,
        Func<T6> sixth,
        Func<T7> seventh)
        =>
        new(
            firstResolver,
            secondResolver,
            thirdResolver,
            fourthResolver,
            fifth,
            sixth,
            seventh);
}