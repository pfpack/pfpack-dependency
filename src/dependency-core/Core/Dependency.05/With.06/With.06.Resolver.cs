using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5>
{
    public Dependency<T1, T2, T3, T4, T5, T6> With<T6>(
        Func<IServiceProvider, T6> sixth)
        =>
        InnerWith(
            sixth ?? throw new ArgumentNullException(nameof(sixth)));

    private Dependency<T1, T2, T3, T4, T5, T6> InnerWith<T6>(
        Func<IServiceProvider, T6> sixthResolver)
        =>
        new(
            firstResolver, secondResolver, thirdResolver, fourthResolver, fifthResolver, sixthResolver);
}