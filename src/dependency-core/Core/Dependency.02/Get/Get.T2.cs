#nullable enable

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public Dependency<T2> GetSecond()
            =>
            new(secondResolver);
    }
}