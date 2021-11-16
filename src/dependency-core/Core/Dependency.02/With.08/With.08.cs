namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    public Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> With<T3, T4, T5, T6, T7, TRest>(
        T3 third,
        T4 fourth,
        T5 fifth,
        T6 sixth,
        T7 seventh,
        TRest rest)
        =>
        new(
            firstResolver,
            secondResolver,
            _ => third,
            _ => fourth,
            _ => fifth,
            _ => sixth,
            _ => seventh,
            _ => rest);
}