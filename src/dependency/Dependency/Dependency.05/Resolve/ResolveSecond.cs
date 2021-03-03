#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5>
    {
        public T2 ResolveSecond(
            IServiceProvider serviceProvider)
            =>
            secondResolver.Invoke(serviceProvider);
    }
}