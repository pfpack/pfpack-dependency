#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5>
    {
        public static Dependency<T1, T2, T3, T4, T5> Create(
            Func<T1> first,
            Func<T2> second,
            Func<T3> third,
            Func<T4> fourth,
            Func<T5> fifth)
            =>
            throw new NotImplementedException();
    }
}