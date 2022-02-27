namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    internal InternalDependencyResolver<T2> InternalToSecondResolver()
        =>
        secondResolver;
}