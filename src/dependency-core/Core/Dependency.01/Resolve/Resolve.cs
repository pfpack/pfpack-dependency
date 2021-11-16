using System;

namespace PrimeFuncPack;

partial class Dependency<T>
{
    public T Resolve(
        IServiceProvider serviceProvider)
        =>
        resolver.Invoke(serviceProvider);
}