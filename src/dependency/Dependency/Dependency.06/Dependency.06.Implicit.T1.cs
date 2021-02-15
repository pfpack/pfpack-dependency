#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6>
    {
        public static implicit operator Func<IServiceProvider, T1>(
            Dependency<T1, T2, T3, T4, T5, T6> dependency)
            =>
            throw new NotImplementedException();

        internal static Func<IServiceProvider, T1> InternalToFirstResolver(
            Dependency<T1, T2, T3, T4, T5, T6> dependency)
            =>
            dependency.firstResolver;
    }
}