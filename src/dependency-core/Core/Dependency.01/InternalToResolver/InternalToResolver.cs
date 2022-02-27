namespace PrimeFuncPack;

partial class Dependency<T>
{
    internal InternalDependencyResolver<T> InternalToResolver()
        =>
        resolver;
}