#nullable enable

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6>
    {
        public Dependency<T2> GetSecond()
            =>
            new(secondResolver);
    }
}