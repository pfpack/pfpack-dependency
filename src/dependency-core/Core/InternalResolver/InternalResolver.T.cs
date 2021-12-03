using System;
using System.Diagnostics.CodeAnalysis;

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
        IsDependency ? dependency : resolver.Invoke(serviceProvider);

    [MemberNotNullWhen(true, nameof(dependency))]
    [MemberNotNullWhen(false, nameof(resolver))]
    private bool IsDependency => isDependency;
}
