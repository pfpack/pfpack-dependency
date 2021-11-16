using System;

namespace PrimeFuncPack;

partial class Dependency<T>
{
    public Dependency<T, T2, T3, T4> With<T2, T3, T4>(
        Func<T2> second,
        Func<T3> third,
        Func<T4> fourth)
        =>
        InnerWith(
            second ?? throw new ArgumentNullException(nameof(second)),
            third ?? throw new ArgumentNullException(nameof(third)),
            fourth ?? throw new ArgumentNullException(nameof(fourth)));

    private Dependency<T, T2, T3, T4> InnerWith<T2, T3, T4>(
        Func<T2> second,
        Func<T3> third,
        Func<T4> fourth)
        =>
        new(
            resolver,
            _ => second.Invoke(),
            _ => third.Invoke(),
            _ => fourth.Invoke());
}