namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5, T6, T7>
{
    public static Dependency<T1, T2, T3, T4, T5, T6, T7> Of(
        T1 first,
        T2 second,
        T3 third,
        T4 fourth,
        T5 fifth,
        T6 sixth,
        T7 seventh)
        =>
        new(
            first, second, third, fourth, fifth, sixth, seventh);
}