#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5>
    {
        public Func<IServiceProvider, T2> ToSecondResolver()
            =>
            secondResolver;
    }
}