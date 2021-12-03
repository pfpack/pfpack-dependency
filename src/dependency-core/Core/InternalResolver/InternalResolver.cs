using System;

namespace PrimeFuncPack;

internal static class InternalResolver
{
    public static InternalResolver<TDependency> Of<TDependency>(TDependency dependency)
        =>
        new(dependency);

    public static InternalResolver<TDependency> From<TDependency>(Func<IServiceProvider, TDependency> resolver)
        =>
        new(resolver);
}
