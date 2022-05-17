namespace PrimeFuncPack;

public sealed partial class Dependency<T1, T2>
{
    private readonly InternalDependencyResolver<T1> firstResolver;

    private readonly InternalDependencyResolver<T2> secondResolver;

    internal Dependency(
        InternalDependencyResolver<T1> firstResolver,
        InternalDependencyResolver<T2> secondResolver)
    {
        this.firstResolver = firstResolver;
        this.secondResolver = secondResolver;
    }
}