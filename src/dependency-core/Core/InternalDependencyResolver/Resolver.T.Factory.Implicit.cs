using System;

namespace PrimeFuncPack;

partial class InternalDependencyResolver<TDependency>
{
    public static implicit operator InternalDependencyResolver<TDependency>(
        TDependency instance)
        =>
        new(instance);

    public static implicit operator InternalDependencyResolver<TDependency>(
        Func<TDependency> factory)
        =>
        new(factory);

    public static implicit operator InternalDependencyResolver<TDependency>(
        Func<IServiceProvider, TDependency> resolver)
        =>
        new(resolver);
}
