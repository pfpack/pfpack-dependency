#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency
    {
        public static Dependency<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(
            Func<IServiceProvider, T1> first,
            Func<IServiceProvider, T2> second,
            Func<IServiceProvider, T3> third,
            Func<IServiceProvider, T4> fourth,
            Func<IServiceProvider, T5> fifth,
            Func<IServiceProvider, T5> sixth)
            =>
            throw new NotImplementedException();
    }
}