namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    public static Dependency<T1, T2> Of(
        T1 first,
        T2 second)
        =>
        InternalOf(
            first, second);

    internal static Dependency<T1, T2> InternalOf(
        T1 first,
        T2 second)
        =>
        new(
            _ => first,
            _ => second);
}