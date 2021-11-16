namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7> With<T5, T6, T7>(
        T5 fifth,
        T6 sixth,
        T7 seventh)
        =>
        new(
            firstResolver,
            secondResolver,
            thirdResolver,
            fourthResolver,
            _ => fifth,
            _ => sixth,
            _ => seventh);
}