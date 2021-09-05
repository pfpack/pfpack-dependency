#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency
    {
        public static Dependency<T1, T2> Create<T1, T2>(
            Func<T1> first,
            Func<T2> second)
            =>
            Dependency<T1, T2>.InternalCreate(
                first ?? throw new ArgumentNullException(nameof(first)),
                second ?? throw new ArgumentNullException(nameof(second)));
    }
}