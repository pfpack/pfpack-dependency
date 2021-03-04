#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6, T7>
    {
        public static implicit operator Func<IServiceProvider, T4>(
            Dependency<T1, T2, T3, T4, T5, T6, T7> dependency)
            =>
            throw new NotImplementedException();
    }
}