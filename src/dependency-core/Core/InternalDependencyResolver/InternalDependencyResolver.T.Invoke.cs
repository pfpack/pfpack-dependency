using System;

namespace PrimeFuncPack;

partial class InternalDependencyResolver<TDependency>
{
    public TDependency Invoke(IServiceProvider serviceProvider) => tag switch
    {
        InternalDependencyResolverTag.Instance
        =>
        instance!,

        InternalDependencyResolverTag.Factory
        =>
        factory!.Invoke(),

        InternalDependencyResolverTag.Resolver
        =>
        resolver!.Invoke(serviceProvider),

        _ => throw new InvalidOperationException("An unexpected tag value.")
    };
}
