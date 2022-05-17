namespace PrimeFuncPack;

public sealed partial class Dependency<T>
{
    private readonly InternalDependencyResolver<T> resolver;

    internal Dependency(
        InternalDependencyResolver<T> resolver)
        =>
        this.resolver = resolver;
}