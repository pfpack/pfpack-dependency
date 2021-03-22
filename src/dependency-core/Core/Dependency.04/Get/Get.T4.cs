#nullable enable

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        public Dependency<T4> GetFourth()
            =>
            new(fourthResolver);
    }
}