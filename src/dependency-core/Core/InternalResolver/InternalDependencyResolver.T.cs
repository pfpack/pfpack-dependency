using System;

namespace PrimeFuncPack;

internal sealed class InternalDependencyResolver<TDependency>
{
    private readonly InternalDependencyResolverTag tag;

    private readonly TDependency? instance;

    private readonly Func<TDependency>? factory;

    private readonly Func<IServiceProvider, TDependency>? resolver;

    private InternalDependencyResolver(
        TDependency instance)
        =>
        (this.instance, tag) = (instance, InternalDependencyResolverTag.Instance);

    private InternalDependencyResolver(
        Func<TDependency> factory)
        =>
        (this.factory, tag) = (factory, InternalDependencyResolverTag.Factory);

    private InternalDependencyResolver(
        Func<IServiceProvider, TDependency> resolver)
        =>
        (this.resolver, tag) = (resolver, InternalDependencyResolverTag.Resolver);

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

    public TDependency Invoke(IServiceProvider serviceProvider)
        =>
        tag switch
        {
            InternalDependencyResolverTag.Instance => instance!,
            InternalDependencyResolverTag.Factory => factory!.Invoke(),
            InternalDependencyResolverTag.Resolver => resolver!.Invoke(serviceProvider),
            _ => throw new InvalidOperationException("An unexpected tag value.")
        };
}
