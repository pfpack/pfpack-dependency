#nullable enable

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6, T7>
    {
        public Dependency<T5> GetFifth()
            =>
            new(fifthResolver);
    }
}