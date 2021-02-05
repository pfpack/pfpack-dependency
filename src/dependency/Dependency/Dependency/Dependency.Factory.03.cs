#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency
    {
        public static Dependency<T1, T2, T3> Create<T1, T2, T3>(
            Func<IServiceProvider, T1> first,
            Func<IServiceProvider, T2> second,
            Func<IServiceProvider, T3> third)
            =>
            new(
                first ?? throw new ArgumentNullException(nameof(first)),
                second ?? throw new ArgumentNullException(nameof(second)),
                third ?? throw new ArgumentNullException(nameof(third)));
    }
}