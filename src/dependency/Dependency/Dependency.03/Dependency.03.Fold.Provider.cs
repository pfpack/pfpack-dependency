#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public Dependency<TR> Fold<TR>(
            Func<IServiceProvider, T1, T2, T3, TR> fold)
            =>
            InternalFold(
                fold ?? throw new ArgumentNullException(nameof(fold)));
        
        private Dependency<TR> InternalFold<TR>(
            Func<IServiceProvider, T1, T2, T3, TR> fold)
            =>
            Dependency<TR>.InternalCreate(
                sp => fold.Invoke(
                    sp,
                    firstResolver.Invoke(sp),
                    secondResolver.Invoke(sp),
                    thirdResolver.Invoke(sp)));
    }
}