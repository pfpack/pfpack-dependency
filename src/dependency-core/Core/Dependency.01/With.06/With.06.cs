namespace PrimeFuncPack;

partial class Dependency<T>
{
    public Dependency<T, T2, T3, T4, T5, T6> With<T2, T3, T4, T5, T6>(
        T2 second,
        T3 third,
        T4 fourth,
        T5 fifth,
        T6 sixth)
        =>
        new(
            resolver,
            _ => second,
            _ => third,
            _ => fourth,
            _ => fifth,
            _ => sixth);
}