#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public Func<IServiceProvider, T3> ToThirdResolver()
            =>
            thirdResolver;
    }
}