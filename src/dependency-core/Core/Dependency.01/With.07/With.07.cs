#nullable enable

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Dependency<T, T2, T3, T4, T5, T6, T7> With<T2, T3, T4, T5, T6, T7>(
            T2 second,
            T3 third,
            T4 fourth,
            T5 fifth,
            T6 sixth,
            T7 seventh)
            =>
            new(
                resolver,
                _ => second,
                _ => third,
                _ => fourth,
                _ => fifth,
                _ => sixth,
                _ => seventh);
    }
}