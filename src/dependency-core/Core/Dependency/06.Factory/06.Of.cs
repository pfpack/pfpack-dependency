#nullable enable

namespace PrimeFuncPack
{
    partial class Dependency
    {
        public static Dependency<T1, T2, T3, T4, T5, T6> Of<T1, T2, T3, T4, T5, T6>(
            T1 first,
            T2 second,
            T3 third,
            T4 fourth,
            T5 fifth,
            T6 sixth)
            =>
            Dependency<T1, T2, T3, T4, T5, T6>.InternalOf(
                first, second, third, fourth, fifth, sixth);
    }
}