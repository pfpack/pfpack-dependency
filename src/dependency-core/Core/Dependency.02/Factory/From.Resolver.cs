#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public static Dependency<T1, T2> From(
            Func<IServiceProvider, T1> first,
            Func<IServiceProvider, T2> second)
            =>
            new(
                first ?? throw new ArgumentNullException(nameof(first)),
                second ?? throw new ArgumentNullException(nameof(second)));
    }
}