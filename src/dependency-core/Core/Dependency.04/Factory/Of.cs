namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4>
{
    public static Dependency<T1, T2, T3, T4> Of(
        T1 first,
        T2 second,
        T3 third,
        T4 fourth)
        =>
        InternalOf(
            first, second, third, fourth);

    internal static Dependency<T1, T2, T3, T4> InternalOf(
        T1 first,
        T2 second,
        T3 third,
        T4 fourth)
        =>
        new(
            first,
            second,
            third,
            fourth);
}