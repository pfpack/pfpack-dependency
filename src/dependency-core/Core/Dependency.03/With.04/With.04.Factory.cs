using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3>
{
    public Dependency<T1, T2, T3, T4> With<T4>(
        Func<T4> fourth)
        =>
        InnerWith(
            fourth ?? throw new ArgumentNullException(nameof(fourth)));

    private Dependency<T1, T2, T3, T4> InnerWith<T4>(
        Func<T4> fourth)
        =>
        new(
            firstResolver,
            secondResolver,
            thirdResolver,
            fourth);
}