using System;

namespace PrimeFuncPack;

partial class InternalDependencyResolver<TDependency>
{
    public TDependency Invoke(IServiceProvider serviceProvider) => tag switch
    {
        Tag.Instance => instance!,

        Tag.Factory => factory!.Invoke(),

        Tag.Resolver => resolver!.Invoke(serviceProvider),

        _ => throw new InvalidOperationException("An unexpected tag value.")
    };
}
