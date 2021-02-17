#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6>
    {
        public static implicit operator Func<IServiceProvider, T2>(
            Dependency<T1, T2, T3, T4, T5, T6> dependency)
            =>
            InternalToSecondResolver(
                dependency ?? throw new ArgumentNullException(nameof(dependency)));

        internal static Func<IServiceProvider, T2> InternalToSecondResolver(
            Dependency<T1, T2, T3, T4, T5, T6> dependency)
            =>
            dependency.secondResolver;
    }
}