#nullable enable

using System;

namespace PrimeFuncPack
{
    public sealed partial class Dependency<T>
    {
        private readonly Func<IServiceProvider, T> resolver;

        internal Dependency(
            Func<IServiceProvider, T> resolver)
            =>
            this.resolver = resolver;
    }
}