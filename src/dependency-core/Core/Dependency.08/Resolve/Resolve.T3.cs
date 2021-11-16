using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5, T6, T7, TRest>
{
    public T3 ResolveThird(
        IServiceProvider serviceProvider)
        =>
        thirdResolver.Invoke(serviceProvider);
}