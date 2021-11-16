namespace PrimeFuncPack;

partial class Dependency
{
    public static Dependency<T1, T2> Of<T1, T2>(
        T1 first,
        T2 second)
        =>
        Dependency<T1, T2>.InternalOf(
            first, second);
}