using System;

namespace PrimeFuncPack;

partial class InternalDependencyResolver<TDependency>
{
    public InternalDependencyResolver(
        TDependency instance)
        =>
        (this.instance, tag) = (instance, InternalDependencyResolverTag.Instance);

    public InternalDependencyResolver(
        Func<TDependency> factory)
        =>
        (this.factory, tag) = (factory, InternalDependencyResolverTag.Factory);

    public InternalDependencyResolver(
        Func<IServiceProvider, TDependency> resolver)
        =>
        (this.resolver, tag) = (resolver, InternalDependencyResolverTag.Resolver);
}
