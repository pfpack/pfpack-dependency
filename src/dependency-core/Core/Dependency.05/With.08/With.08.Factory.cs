using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> With<T6, T7, TRest>(
        Func<T6> sixth,
        Func<T7> seventh,
        Func<TRest> rest)
        =>
        InnerWith(
            sixth ?? throw new ArgumentNullException(nameof(sixth)),
            seventh ?? throw new ArgumentNullException(nameof(seventh)),
            rest ?? throw new ArgumentNullException(nameof(rest)));

    private Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> InnerWith<T6, T7, TRest>(
        Func<T6> sixth,
        Func<T7> seventh,
        Func<TRest> rest)
        =>
        new(
            firstResolver,
            secondResolver,
            thirdResolver,
            fourthResolver,
            fifthResolver,
            _ => sixth.Invoke(),
            _ => seventh.Invoke(),
            _ => rest.Invoke());
}