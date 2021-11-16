namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    public Dependency<T1> GetFirst()
        =>
        new(firstResolver);
}