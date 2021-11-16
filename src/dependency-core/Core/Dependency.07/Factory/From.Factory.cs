using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5, T6, T7>
{
    public static Dependency<T1, T2, T3, T4, T5, T6, T7> From(
        Func<T1> first,
        Func<T2> second,
        Func<T3> third,
        Func<T4> fourth,
        Func<T5> fifth,
        Func<T6> sixth,
        Func<T7> seventh)
        =>
        InternalFrom(
            first ?? throw new ArgumentNullException(nameof(first)),
            second ?? throw new ArgumentNullException(nameof(second)),
            third ?? throw new ArgumentNullException(nameof(third)),
            fourth ?? throw new ArgumentNullException(nameof(fourth)),
            fifth ?? throw new ArgumentNullException(nameof(fifth)),
            sixth ?? throw new ArgumentNullException(nameof(sixth)),
            seventh ?? throw new ArgumentNullException(nameof(seventh)));

    internal static Dependency<T1, T2, T3, T4, T5, T6, T7> InternalFrom(
        Func<T1> first,
        Func<T2> second,
        Func<T3> third,
        Func<T4> fourth,
        Func<T5> fifth,
        Func<T6> sixth,
        Func<T7> seventh)
        =>
        new(
            _ => first.Invoke(),
            _ => second.Invoke(),
            _ => third.Invoke(),
            _ => fourth.Invoke(),
            _ => fifth.Invoke(),
            _ => sixth.Invoke(),
            _ => seventh.Invoke());
}