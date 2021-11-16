namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3>
{
    public Dependency<T1, T2, T3, T4, T5> With<T4, T5>(
        T4 fourth,
        T5 fifth)
        =>
        new(
            firstResolver,
            secondResolver,
            thirdResolver,
            _ => fourth,
            _ => fifth);
}