using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5>
{
    public static Dependency<T1, T2, T3, T4, T5> From(
        Func<T1> first,
        Func<T2> second,
        Func<T3> third,
        Func<T4> fourth,
        Func<T5> fifth)
        =>
        InternalFrom(
            first ?? throw new ArgumentNullException(nameof(first)),
            second ?? throw new ArgumentNullException(nameof(second)),
            third ?? throw new ArgumentNullException(nameof(third)),
            fourth ?? throw new ArgumentNullException(nameof(fourth)),
            fifth ?? throw new ArgumentNullException(nameof(fifth)));

    internal static Dependency<T1, T2, T3, T4, T5> InternalFrom(
        Func<T1> first,
        Func<T2> second,
        Func<T3> third,
        Func<T4> fourth,
        Func<T5> fifth)
        =>
        new(
            _ => first.Invoke(),
            _ => second.Invoke(),
            _ => third.Invoke(),
            _ => fourth.Invoke(),
            _ => fifth.Invoke());
}