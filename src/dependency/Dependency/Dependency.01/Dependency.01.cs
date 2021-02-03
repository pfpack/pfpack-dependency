#nullable enable

using System;

namespace PrimeFuncPack
{
    public sealed partial class Dependency<T>
    {
        private readonly Func<IServiceProvider, T> resolver;

        private Dependency(
            Func<IServiceProvider, T> resolver)
            =>
            this.resolver = resolver;

        internal Func<IServiceProvider, T> InternalResolver
            =>
            resolver;
    }
}