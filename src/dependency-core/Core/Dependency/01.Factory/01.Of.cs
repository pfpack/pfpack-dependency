namespace PrimeFuncPack;

partial class Dependency
{
    public static Dependency<T> Of<T>(
        T single)
        =>
        new(
            single);
}