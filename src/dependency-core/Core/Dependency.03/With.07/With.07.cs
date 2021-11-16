namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7> With<T4, T5, T6, T7>(
        T4 fourth,
        T5 fifth,
        T6 sixth,
        T7 seventh)
        =>
        new(
            firstResolver,
            secondResolver,
            thirdResolver,
            _ => fourth,
            _ => fifth,
            _ => sixth,
            _ => seventh);
}