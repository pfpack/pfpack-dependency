#nullable enable

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public Dependency<T1> GetFirst()
            =>
            new(firstResolver);
    }
}