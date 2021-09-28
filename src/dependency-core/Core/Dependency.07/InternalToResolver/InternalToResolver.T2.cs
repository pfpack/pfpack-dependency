#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6, T7>
    {
        internal Func<IServiceProvider, T2> InternalToSecondResolver()
            =>
            secondResolver;
    }
}