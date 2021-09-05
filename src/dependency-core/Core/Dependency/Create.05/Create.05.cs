#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency
    {
        public static Dependency<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(
            Func<T1> first,
            Func<T2> second,
            Func<T3> third,
            Func<T4> fourth,
            Func<T5> fifth)
            =>
            Dependency<T1, T2, T3, T4, T5>.InternalCreate(
                first ?? throw new ArgumentNullException(nameof(first)),
                second ?? throw new ArgumentNullException(nameof(second)),
                third ?? throw new ArgumentNullException(nameof(third)),
                fourth ?? throw new ArgumentNullException(nameof(fourth)),
                fifth ?? throw new ArgumentNullException(nameof(fifth)));
    }
}