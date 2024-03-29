using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5, T6, T7>
{
    public Dependency<TResult> Fold<TResult>(
        Func<T1, T2, T3, T4, T5, T6, T7, TResult> fold)
        =>
        InnerFold(
            fold ?? throw new ArgumentNullException(nameof(fold)));

    private Dependency<TResult> InnerFold<TResult>(
        Func<T1, T2, T3, T4, T5, T6, T7, TResult> fold)
        =>
        new(new(
            sp => fold.Invoke(
                firstResolver.Invoke(sp),
                secondResolver.Invoke(sp),
                thirdResolver.Invoke(sp),
                fourthResolver.Invoke(sp),
                fifthResolver.Invoke(sp),
                sixthResolver.Invoke(sp),
                seventhResolver.Invoke(sp))));
}