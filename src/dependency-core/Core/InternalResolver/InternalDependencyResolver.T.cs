using System;

namespace PrimeFuncPack;

internal sealed class InternalDependencyResolver<TDependency>
{
    private readonly InternalDependencyResolverTag tag;

    private readonly TDependency? instance;

    private readonly Func<TDependency>? factory;

    private readonly Func<IServiceProvider, TDependency>? resolver;

    internal InternalDependencyResolver(TDependency instance)
        =>
        (this.instance, tag) = (instance, InternalDependencyResolverTag.Instance);

    internal InternalDependencyResolver(Func<TDependency> factory)
        =>
        (this.factory, tag) = (factory, InternalDependencyResolverTag.Factory);

    internal InternalDependencyResolver(Func<IServiceProvider, TDependency> resolver)
        =>
        (this.resolver, tag) = (resolver, InternalDependencyResolverTag.Resolver);

    internal TDependency Invoke(IServiceProvider serviceProvider)
        =>
        tag switch
        {
            InternalDependencyResolverTag.Instance => instance!,
            InternalDependencyResolverTag.Factory => factory!.Invoke(),
            InternalDependencyResolverTag.Resolver => resolver!.Invoke(serviceProvider),
            _ => throw new InvalidOperationException("An unexpected tag value.")
        };
}
