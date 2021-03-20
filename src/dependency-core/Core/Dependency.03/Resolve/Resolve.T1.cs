#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public T1 ResolveFirst(
            IServiceProvider serviceProvider)
            =>
            firstResolver.Invoke(serviceProvider);
    }
}