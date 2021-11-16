using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    public T2 ResolveSecond(
        IServiceProvider serviceProvider)
        =>
        secondResolver.Invoke(serviceProvider);
}