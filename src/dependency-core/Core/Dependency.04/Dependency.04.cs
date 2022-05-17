namespace PrimeFuncPack;

public sealed partial class Dependency<T1, T2, T3, T4>
{
    private readonly InternalDependencyResolver<T1> firstResolver;

    private readonly InternalDependencyResolver<T2> secondResolver;

    private readonly InternalDependencyResolver<T3> thirdResolver;

    private readonly InternalDependencyResolver<T4> fourthResolver;

    internal Dependency(
        InternalDependencyResolver<T1> firstResolver,
        InternalDependencyResolver<T2> secondResolver,
        InternalDependencyResolver<T3> thirdResolver,
        InternalDependencyResolver<T4> fourthResolver)
    {
        this.firstResolver = firstResolver;
        this.secondResolver = secondResolver;
        this.thirdResolver = thirdResolver;
        this.fourthResolver = fourthResolver;
    }
}