#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency
    {
        public static Dependency<T1, T2> Create<T1, T2>(
            Func<IServiceProvider, T1> first,
            Func<IServiceProvider, T2> second)
            =>
            new(
                first ?? throw new ArgumentNullException(nameof(first)),
                second ?? throw new ArgumentNullException(nameof(second)));
    }
}