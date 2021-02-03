#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency
    {
        public static Dependency<T1> Create<T1>(
            Func<IServiceProvider, T1> first)
            =>
            Dependency<T1>.InternalCreate(
                first ?? throw new ArgumentNullException(nameof(first)));
    }
}