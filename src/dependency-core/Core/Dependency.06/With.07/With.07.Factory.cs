using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5, T6>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7> With<T7>(
        Func<T7> seventh)
        =>
        InnerWith(
            seventh ?? throw new ArgumentNullException(nameof(seventh)));

    private Dependency<T1, T2, T3, T4, T5, T6, T7> InnerWith<T7>(
        Func<T7> seventh)
        =>
        new(
            firstResolver,
            secondResolver,
            thirdResolver,
            fourthResolver,
            fifthResolver,
            sixthResolver,
            _ => seventh.Invoke());
}