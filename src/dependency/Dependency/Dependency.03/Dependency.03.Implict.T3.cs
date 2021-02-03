#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public static implicit operator Func<IServiceProvider, T3>(
            Dependency<T1, T2, T3> dependency)
            =>
            InternalToThirdResolver(
                dependency ?? throw new ArgumentNullException(nameof(dependency)));

        private static Func<IServiceProvider, T3> InternalToThirdResolver(
            Dependency<T1, T2, T3> dependency)
            =>
            dependency.thirdResolver;
    }
}