using System;

namespace PrimeFuncPack;

internal sealed class InternalResolver<TDependency>
{
    private readonly bool isDependencyTag;

    private readonly TDependency? dependency;

    private readonly Func<IServiceProvider, TDependency>? resolver;

    internal InternalResolver(TDependency dependency)
        =>
        (this.dependency, isDependencyTag) = (dependency, true);

    internal InternalResolver(Func<IServiceProvider, TDependency> resolver)
        =>
        this.resolver = resolver;

    internal TDependency Invoke(IServiceProvider serviceProvider)
        =>
        isDependencyTag ? dependency! : resolver!.Invoke(serviceProvider);
}
