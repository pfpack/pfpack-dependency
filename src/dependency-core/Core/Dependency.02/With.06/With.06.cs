namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    public Dependency<T1, T2, T3, T4, T5, T6> With<T3, T4, T5, T6>(
        T3 third,
        T4 fourth,
        T5 fifth,
        T6 sixth)
        =>
        new(
            firstResolver,
            secondResolver,
            third,
            fourth,
            fifth,
            sixth);
}