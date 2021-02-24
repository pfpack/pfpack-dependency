#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6>
    {
        public Func<IServiceProvider, T6> ToSixthResolver()
            =>
            sixthResolver;
        
        public static implicit operator Func<IServiceProvider, T6>(
            Dependency<T1, T2, T3, T4, T5, T6> dependency)
            =>
            InternalToSixthResolver(
                dependency ?? throw new ArgumentNullException(nameof(dependency)));

        internal static Func<IServiceProvider, T6> InternalToSixthResolver(
            Dependency<T1, T2, T3, T4, T5, T6> dependency)
            =>
            dependency.sixthResolver;
    }
}