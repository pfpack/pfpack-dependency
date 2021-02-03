#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        internal static Dependency<T> InternalCreate(
            Func<IServiceProvider, T> resolver)
            =>
            new(resolver);
    }
}