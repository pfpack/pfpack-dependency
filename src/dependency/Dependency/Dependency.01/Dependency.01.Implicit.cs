#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public static implicit operator Func<IServiceProvider, T>(
            Dependency<T> dependency)
            =>
            InternalToResolver(
                dependency ?? throw new ArgumentNullException(nameof(dependency)));

        private static Func<IServiceProvider, T> InternalToResolver(
            Dependency<T> dependency)
            =>
            dependency.resolver;
    }
}