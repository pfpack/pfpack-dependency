namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5, T6>
{
    public static Dependency<T1, T2, T3, T4, T5, T6> Of(
        T1 first,
        T2 second,
        T3 third,
        T4 fourth,
        T5 fifth,
        T6 sixth)
        =>
        InternalOf(
            first, second, third, fourth, fifth, sixth);

    internal static Dependency<T1, T2, T3, T4, T5, T6> InternalOf(
        T1 first,
        T2 second,
        T3 third,
        T4 fourth,
        T5 fifth,
        T6 sixth)
        =>
        new(
            first,
            second,
            third,
            fourth,
            fifth,
            sixth);
}