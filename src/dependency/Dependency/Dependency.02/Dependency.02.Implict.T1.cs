#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public static implicit operator Func<IServiceProvider, T1>(
            Dependency<T1, T2> dependency)
            =>
            InternalToFirstResolver(
                dependency ?? throw new ArgumentNullException(nameof(dependency)));

        private static Func<IServiceProvider, T1> InternalToFirstResolver(
            Dependency<T1, T2> dependency)
            =>
            dependency.firstResolver;
    }
}