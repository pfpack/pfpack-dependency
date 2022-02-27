namespace PrimeFuncPack;

public sealed partial class Dependency<T1, T2, T3>
{
    private readonly InternalDependencyResolver<T1> firstResolver;

    private readonly InternalDependencyResolver<T2> secondResolver;

    private readonly InternalDependencyResolver<T3> thirdResolver;

    internal Dependency(
        InternalDependencyResolver<T1> firstResolver,
        InternalDependencyResolver<T2> secondResolver,
        InternalDependencyResolver<T3> thirdResolver)
    {
        this.firstResolver = firstResolver;
        this.secondResolver = secondResolver;
        this.thirdResolver = thirdResolver;
    }
}