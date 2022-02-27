using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4>
{
    public static Dependency<T1, T2, T3, T4> From(
        Func<T1> first,
        Func<T2> second,
        Func<T3> third,
        Func<T4> fourth)
        =>
        new(
            first ?? throw new ArgumentNullException(nameof(first)),
            second ?? throw new ArgumentNullException(nameof(second)),
            third ?? throw new ArgumentNullException(nameof(third)),
            fourth ?? throw new ArgumentNullException(nameof(fourth)));
}