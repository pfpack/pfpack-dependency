namespace PrimeFuncPack;

partial class Dependency<T>
{
    public Dependency<T, T2, T3> With<T2, T3>(
        T2 second,
        T3 third)
        =>
        new(
            resolver,
            _ => second,
            _ => third);
}