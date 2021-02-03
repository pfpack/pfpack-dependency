#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        internal static Dependency<T1, T2, T3, T4> InternalCreate(
            Func<IServiceProvider, T1> firstResolver,
            Func<IServiceProvider, T2> secondResolver,
            Func<IServiceProvider, T3> thirdResolver,
            Func<IServiceProvider, T4> fourthResolver)
            =>
            new(firstResolver, secondResolver, thirdResolver, fourthResolver);
    }
}