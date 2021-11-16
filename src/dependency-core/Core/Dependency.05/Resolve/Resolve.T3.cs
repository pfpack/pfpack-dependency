using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5>
{
    public T3 ResolveThird(
        IServiceProvider serviceProvider)
        =>
        thirdResolver.Invoke(serviceProvider);
}