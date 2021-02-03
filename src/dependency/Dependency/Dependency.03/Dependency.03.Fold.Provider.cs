#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public Dependency<TR> Fold<TR>(
            Func<IServiceProvider, T1, T2, T3, TR> map)
            =>
            InternalFold(
                map ?? throw new ArgumentNullException(nameof(map)));
        
        private Dependency<TR> InternalFold<TR>(
            Func<IServiceProvider, T1, T2, T3, TR> map)
            =>
            Dependency<TR>.InternalCreate(
                sp => map.Invoke(
                    sp,
                    firstResolver.Invoke(sp),
                    secondResolver.Invoke(sp),
                    thirdResolver.Invoke(sp)));
    }
}