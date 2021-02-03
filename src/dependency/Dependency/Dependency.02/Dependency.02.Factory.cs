#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        internal static Dependency<T1, T2> InternalCreate(
            Func<IServiceProvider, T1> firstResolver,
            Func<IServiceProvider, T2> secondResolver)
            =>
            new(firstResolver, secondResolver);
    }
}