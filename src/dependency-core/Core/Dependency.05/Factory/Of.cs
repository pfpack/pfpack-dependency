#nullable enable

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5>
    {
        public static Dependency<T1, T2, T3, T4, T5> Of(
            T1 first,
            T2 second,
            T3 third,
            T4 fourth,
            T5 fifth)
            =>
            InternalOf(
                first, second, third, fourth, fifth);

        internal static Dependency<T1, T2, T3, T4, T5> InternalOf(
            T1 first,
            T2 second,
            T3 third,
            T4 fourth,
            T5 fifth)
            =>
            new(
                _ => first,
                _ => second,
                _ => third,
                _ => fourth,
                _ => fifth);
    }
}