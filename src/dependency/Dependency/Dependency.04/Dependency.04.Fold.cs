#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        public Dependency<TR> Fold<TR>(
            Func<T1, T2, T3, T4, TR> fold)
            =>
            InternalFold(
                fold ?? throw new ArgumentNullException(nameof(fold)));
        
        private Dependency<TR> InternalFold<TR>(
            Func<T1, T2, T3, T4, TR> fold)
            =>
            Dependency<TR>.InternalCreate(
                sp => fold.Invoke(
                    firstResolver.Invoke(sp),
                    secondResolver.Invoke(sp),
                    thirdResolver.Invoke(sp),
                    fourthResolver.Invoke(sp)));
    }
}