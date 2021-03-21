#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        internal Func<IServiceProvider, T> ToResolver()
            =>
            resolver;
    }
}