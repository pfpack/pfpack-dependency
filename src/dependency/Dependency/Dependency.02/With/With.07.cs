#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public Dependency<T1, T2, T3, T4, T5, T6, T7> With<T3, T4, T5, T6, T7>(
            Dependency<T3, T4, T5, T6, T7> other)
            =>
            throw new NotImplementedException();

        private Dependency<T1, T2, T3, T4, T5, T6, T7> InternalWith<T3, T4, T5, T6, T7>(
            Dependency<T3, T4, T5, T6, T7> other)
            =>
            new(
                firstResolver,
                secondResolver,
                other.InternalFirstResolver,
                other.InternalSecondResolver,
                other.InternalThirdResolver,
                other.InternalFourthResolver,
                other.InternalFifthResolver);
    }
}