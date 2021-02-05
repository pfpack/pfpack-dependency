#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        public static implicit operator Func<IServiceProvider, T4>(
            Dependency<T1, T2, T3, T4> dependency)
            =>
            InternalToFourthResolver(
                dependency ?? throw new ArgumentNullException(nameof(dependency)));

        private static Func<IServiceProvider, T4> InternalToFourthResolver(
            Dependency<T1, T2, T3, T4> dependency)
            =>
            dependency.fourthResolver;
    }
}