namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4, T5>
{
    public static Dependency<T1, T2, T3, T4, T5> Of(
        T1 first,
        T2 second,
        T3 third,
        T4 fourth,
        T5 fifth)
        =>
        new(
            first, second, third, fourth, fifth);
}