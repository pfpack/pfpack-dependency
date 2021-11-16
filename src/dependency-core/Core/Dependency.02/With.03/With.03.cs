namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    public Dependency<T1, T2, T3> With<T3>(
        T3 third)
        =>
        new(
            firstResolver,
            secondResolver,
            _ => third);
}