using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    public Dependency<TResult> Fold<TResult>(
        Func<IServiceProvider, T1, T2, TResult> fold)
        =>
        InnerFold(
            fold ?? throw new ArgumentNullException(nameof(fold)));

    private Dependency<TResult> InnerFold<TResult>(
        Func<IServiceProvider, T1, T2, TResult> fold)
        =>
        new(new(
            sp => fold.Invoke(
                sp,
                firstResolver.Invoke(sp),
                secondResolver.Invoke(sp))));
}