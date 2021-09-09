#nullable enable

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public Dependency<T1, T2, T3, T4> With<T4>(
            T4 fourth)
            =>
            new(
                firstResolver,
                secondResolver,
                thirdResolver,
                _ => fourth);
    }
}