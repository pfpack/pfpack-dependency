namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    public Dependency<T1, T2, T3, T4> With<T3, T4>(
        T3 third,
        T4 fourth)
        =>
        new(
            firstResolver,
            secondResolver,
            _ => third,
            _ => fourth);
}