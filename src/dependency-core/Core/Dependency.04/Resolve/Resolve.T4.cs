using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4>
{
    public T4 ResolveFourth(
        IServiceProvider serviceProvider)
        =>
        fourthResolver.Invoke(serviceProvider);
}