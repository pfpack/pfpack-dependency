#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5>
    {
        public static implicit operator Func<IServiceProvider, T4>(
            Dependency<T1, T2, T3, T4, T5> dependency)
            =>
            InternalToFourthResolver(
                dependency ?? throw new ArgumentNullException(nameof(dependency)));

        internal static Func<IServiceProvider, T4> InternalToFourthResolver(
            Dependency<T1, T2, T3, T4, T5> dependency)
            =>
            dependency.fourthResolver;
    }
}