#nullable enable

namespace PrimeFuncPack
{
    partial class Dependency
    {
        public static Dependency<T1, T2, T3, T4> Of<T1, T2, T3, T4>(
            T1 first,
            T2 second,
            T3 third,
            T4 fourth)
            =>
            Dependency<T1, T2, T3, T4>.InternalOf(
                first, second, third, fourth);
    }
}