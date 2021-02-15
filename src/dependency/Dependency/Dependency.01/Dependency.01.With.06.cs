#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Dependency<T, T2, T3, T4, T5, T6> With<T2, T3, T4, T5, T6>(
            Dependency<T2, T3, T4, T5, T6> other)
            =>
            throw new NotImplementedException();

        private Dependency<T, T2, T3, T4, T5, T6> InternalWith<T2, T3, T4, T5, T6>(
            Dependency<T2, T3, T4, T5, T6> other)
            =>
            new(
                resolver,
                other.InternalFirstResolver,
                other.InternalSecondResolver,
                other.InternalThirdResolver,
                other.InternalFourthResolver,
                other.InternalFifthResolver);
    }
}