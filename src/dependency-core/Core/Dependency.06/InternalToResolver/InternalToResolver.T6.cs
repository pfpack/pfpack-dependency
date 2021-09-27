#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6>
    {
        internal Func<IServiceProvider, T6> InternalToSixthResolver()
            =>
            sixthResolver;
    }
}