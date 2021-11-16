namespace PrimeFuncPack;

partial class Dependency<T>
{
    public Dependency<T, T2> With<T2>(
        T2 second)
        =>
        new(
            resolver,
            _ => second);
}