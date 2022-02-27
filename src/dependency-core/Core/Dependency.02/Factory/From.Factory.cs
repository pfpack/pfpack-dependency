using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    public static Dependency<T1, T2> From(
        Func<T1> first,
        Func<T2> second)
        =>
        InternalFrom(
            first ?? throw new ArgumentNullException(nameof(first)),
            second ?? throw new ArgumentNullException(nameof(second)));

    internal static Dependency<T1, T2> InternalFrom(
        Func<T1> first,
        Func<T2> second)
        =>
        new(
            first,
            second);
}