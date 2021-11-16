namespace PrimeFuncPack;

partial class Dependency<T>
{
    public static Dependency<T> Of(
        T single)
        =>
        InternalOf(
            single);

    internal static Dependency<T> InternalOf(
        T single)
        =>
        new(
            _ => single);
}