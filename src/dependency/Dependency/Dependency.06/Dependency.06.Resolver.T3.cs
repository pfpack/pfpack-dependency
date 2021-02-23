#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6>
    {
        public Func<IServiceProvider, T3> ToThirdResolver()
            =>
            thirdResolver;
        
        public static implicit operator Func<IServiceProvider, T3>(
            Dependency<T1, T2, T3, T4, T5, T6> dependency)
            =>
            InternalToThirdResolver(
                dependency ?? throw new ArgumentNullException(nameof(dependency)));

        internal static Func<IServiceProvider, T3> InternalToThirdResolver(
            Dependency<T1, T2, T3, T4, T5, T6> dependency)
            =>
            dependency.thirdResolver;
    }
}