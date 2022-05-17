namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3>
{
    internal InternalDependencyResolver<T3> InternalToThirdResolver()
        =>
        thirdResolver;
}