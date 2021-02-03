#nullable enable

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        public Dependency<T4> ToFourth()
            =>
            Dependency<T4>.InternalCreate(fourthResolver);
    }
}