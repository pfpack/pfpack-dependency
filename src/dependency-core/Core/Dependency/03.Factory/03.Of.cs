#nullable enable

namespace PrimeFuncPack
{
    partial class Dependency
    {
        public static Dependency<T1, T2, T3> Of<T1, T2, T3>(
            T1 first,
            T2 second,
            T3 third)
            =>
            Dependency<T1, T2, T3>.InternalOf(
                first, second, third);
    }
}