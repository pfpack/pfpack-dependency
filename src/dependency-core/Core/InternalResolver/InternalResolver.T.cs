using System;

namespace PrimeFuncPack;

internal sealed class InternalResolver<TDependency>
{
    private readonly bool isDependency;

    private readonly TDependency? dependency;

    private readonly Func<IServiceProvider, TDependency>? resolver;

    internal InternalResolver(TDependency dependency)
        =>
        (this.dependency, isDependency) = (dependency, true);

    internal InternalResolver(Func<IServiceProvider, TDependency> resolver)
        =>
        this.resolver = resolver;

    internal TDependency Invoke(IServiceProvider serviceProvider)
        =>
        isDependency ? dependency! : resolver!.Invoke(serviceProvider);
}
