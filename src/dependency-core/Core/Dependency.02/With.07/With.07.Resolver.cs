using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7> With<T3, T4, T5, T6, T7>(
        Func<IServiceProvider, T3> third,
        Func<IServiceProvider, T4> fourth,
        Func<IServiceProvider, T5> fifth,
        Func<IServiceProvider, T6> sixth,
        Func<IServiceProvider, T7> seventh)
        =>
        InnerWith(
            third ?? throw new ArgumentNullException(nameof(third)),
            fourth ?? throw new ArgumentNullException(nameof(fourth)),
            fifth ?? throw new ArgumentNullException(nameof(fifth)),
            sixth ?? throw new ArgumentNullException(nameof(sixth)),
            seventh ?? throw new ArgumentNullException(nameof(seventh)));

    private Dependency<T1, T2, T3, T4, T5, T6, T7> InnerWith<T3, T4, T5, T6, T7>(
        Func<IServiceProvider, T3> thirdResolver,
        Func<IServiceProvider, T4> fourthResolver,
        Func<IServiceProvider, T5> fifthResolver,
        Func<IServiceProvider, T6> sixthResolver,
        Func<IServiceProvider, T7> seventhResolver)
        =>
        new(
            firstResolver, secondResolver, thirdResolver, fourthResolver, fifthResolver, sixthResolver, seventhResolver);
}