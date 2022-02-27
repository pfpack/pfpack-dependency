namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3>
{
    public static Dependency<T1, T2, T3> Of(
        T1 first,
        T2 second,
        T3 third)
        =>
        new(
            first, second, third);
}