#nullable enable

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public Dependency<T3> ToThird()
            =>
            Dependency<T3>.InternalCreate(thirdResolver);
    }
}