#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6>
    {
        public Func<IServiceProvider, T5> ToFifthResolver()
            =>
            fifthResolver;
        
        public static implicit operator Func<IServiceProvider, T5>(
            Dependency<T1, T2, T3, T4, T5, T6> dependency)
            =>
            InternalToFifthResolver(
                dependency ?? throw new ArgumentNullException(nameof(dependency)));

        internal static Func<IServiceProvider, T5> InternalToFifthResolver(
            Dependency<T1, T2, T3, T4, T5, T6> dependency)
            =>
            dependency.fifthResolver;
    }
}