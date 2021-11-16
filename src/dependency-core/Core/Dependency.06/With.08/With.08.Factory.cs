using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5, T6>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> With<T7, TRest>(
        Func<T7> seventh,
        Func<TRest> rest)
        =>
        InnerWith(
            seventh ?? throw new ArgumentNullException(nameof(seventh)),
            rest ?? throw new ArgumentNullException(nameof(rest)));

    private Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> InnerWith<T7, TRest>(
        Func<T7> seventh,
        Func<TRest> rest)
        =>
        new(
            firstResolver,
            secondResolver,
            thirdResolver,
            fourthResolver,
            fifthResolver,
            sixthResolver,
            _ => seventh.Invoke(),
            _ => rest.Invoke());
}