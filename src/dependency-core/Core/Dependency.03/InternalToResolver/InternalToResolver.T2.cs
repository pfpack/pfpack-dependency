namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3>
{
    internal InternalDependencyResolver<T2> InternalToSecondResolver()
        =>
        secondResolver;
}