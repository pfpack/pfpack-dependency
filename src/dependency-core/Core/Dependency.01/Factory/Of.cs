namespace PrimeFuncPack;

partial class Dependency<T>
{
    public static Dependency<T> Of(
        T single)
        =>
        new(
            single);
}