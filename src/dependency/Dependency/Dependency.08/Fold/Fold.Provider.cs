#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6, T7, TRest>
    {
        public Dependency<TResult> Fold<TResult>(
            Func<IServiceProvider, T1, T2, T3, T4, T5, T6, T7, TRest, TResult> fold)
            =>
            InternalFold(
                fold ?? throw new ArgumentNullException(nameof(fold)));
        
        private Dependency<TResult> InternalFold<TResult>(
            Func<IServiceProvider, T1, T2, T3, T4, T5, T6, T7, TRest, TResult> fold)
            =>
            new(
                sp => fold.Invoke(
                    sp,
                    firstResolver.Invoke(sp),
                    secondResolver.Invoke(sp),
                    thirdResolver.Invoke(sp),
                    fourthResolver.Invoke(sp),
                    fifthResolver.Invoke(sp),
                    sixthResolver.Invoke(sp),
                    seventhResolver.Invoke(sp),
                    restResolver.Invoke(sp)));
    }
}