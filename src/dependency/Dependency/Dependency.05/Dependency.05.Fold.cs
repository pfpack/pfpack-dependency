#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5>
    {
        public Dependency<TR> Fold<TR>(
            Func<T1, T2, T3, T4, T5, TR> map)
            =>
            InternalFold(
                map ?? throw new ArgumentNullException(nameof(map)));
        
        private Dependency<TR> InternalFold<TR>(
            Func<T1, T2, T3, T4, T5, TR> map)
            =>
            Dependency<TR>.InternalCreate(
                sp => map.Invoke(
                    firstResolver.Invoke(sp),
                    secondResolver.Invoke(sp),
                    thirdResolver.Invoke(sp),
                    fourthResolver.Invoke(sp),
                    fifthResolver.Invoke(sp)));
    }
}