using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> With<T5, T6, T7, TRest>(
        Func<IServiceProvider, T5> fifth,
        Func<IServiceProvider, T6> sixth,
        Func<IServiceProvider, T7> seventh,
        Func<IServiceProvider, TRest> rest)
        =>
        InnerWith(
            fifth ?? throw new ArgumentNullException(nameof(fifth)),
            sixth ?? throw new ArgumentNullException(nameof(sixth)),
            seventh ?? throw new ArgumentNullException(nameof(seventh)),
            rest ?? throw new ArgumentNullException(nameof(rest)));

    private Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> InnerWith<T5, T6, T7, TRest>(
        Func<IServiceProvider, T5> fifthResolver,
        Func<IServiceProvider, T6> sixthResolver,
        Func<IServiceProvider, T7> seventhResolver,
        Func<IServiceProvider, TRest> restResolver)
        =>
        new(
            firstResolver, secondResolver, thirdResolver, fourthResolver, fifthResolver, sixthResolver, seventhResolver, restResolver);
}