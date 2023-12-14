using System;

namespace PrimeFuncPack;

internal sealed partial class InternalDependencyResolver<TDependency>
{
    private readonly Tag tag;

    private readonly TDependency? instance;

    private readonly Func<TDependency>? factory;

    private readonly Func<IServiceProvider, TDependency>? resolver;
}
