using System;

namespace PrimeFuncPack;

partial class Dependency
{
    public static Dependency<T1, T2, T3, T4> From<T1, T2, T3, T4>(
        Func<T1> first,
        Func<T2> second,
        Func<T3> third,
        Func<T4> fourth)
        =>
        Dependency<T1, T2, T3, T4>.InternalFrom(
            first ?? throw new ArgumentNullException(nameof(first)),
            second ?? throw new ArgumentNullException(nameof(second)),
            third ?? throw new ArgumentNullException(nameof(third)),
            fourth ?? throw new ArgumentNullException(nameof(fourth)));
}