namespace PrimeFuncPack;

public sealed partial class Dependency<T1, T2, T3, T4, T5>
{
    private readonly InternalDependencyResolver<T1> firstResolver;

    private readonly InternalDependencyResolver<T2> secondResolver;

    private readonly InternalDependencyResolver<T3> thirdResolver;

    private readonly InternalDependencyResolver<T4> fourthResolver;

    private readonly InternalDependencyResolver<T5> fifthResolver;

    internal Dependency(
        InternalDependencyResolver<T1> firstResolver,
        InternalDependencyResolver<T2> secondResolver,
        InternalDependencyResolver<T3> thirdResolver,
        InternalDependencyResolver<T4> fourthResolver,
        InternalDependencyResolver<T5> fifthResolver)
    {
        this.firstResolver = firstResolver;
        this.secondResolver = secondResolver;
        this.thirdResolver = thirdResolver;
        this.fourthResolver = fourthResolver;
        this.fifthResolver = fifthResolver;
    }
}