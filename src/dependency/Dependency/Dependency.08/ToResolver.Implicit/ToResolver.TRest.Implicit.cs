#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6, T7, TRest>
    {
        public static implicit operator Func<IServiceProvider, TRest>(
            Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> dependency)
            =>
            throw new NotImplementedException();
    }
}