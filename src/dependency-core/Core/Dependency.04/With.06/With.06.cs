namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4>
{
    public Dependency<T1, T2, T3, T4, T5, T6> With<T5, T6>(
        T5 fifth,
        T6 sixth)
        =>
        new(
            firstResolver,
            secondResolver,
            thirdResolver,
            fourthResolver,
            _ => fifth,
            _ => sixth);
}