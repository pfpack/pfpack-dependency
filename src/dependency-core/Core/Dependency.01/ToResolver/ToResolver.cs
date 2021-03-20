#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Func<IServiceProvider, T> ToResolver()
            =>
            resolver;
    }
}