#nullable enable

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public Dependency<T1, T2, T3, T4, T5> With<T3, T4, T5>(
            T3 third,
            T4 fourth,
            T5 fifth)
            =>
            new(
                firstResolver,
                secondResolver,
                _ => third,
                _ => fourth,
                _ => fifth);
    }
}