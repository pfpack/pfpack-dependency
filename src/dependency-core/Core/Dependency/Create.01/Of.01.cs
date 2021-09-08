#nullable enable

namespace PrimeFuncPack
{
    partial class Dependency
    {
        public static Dependency<T> Of<T>(
            T single)
            =>
            Dependency<T>.InternalOf(
                single);
    }
}