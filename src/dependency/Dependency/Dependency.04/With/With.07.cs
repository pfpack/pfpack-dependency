#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        public Dependency<T1, T2, T3, T4, T5, T6, T7> With<T5, T6, T7>(
            Dependency<T5, T6, T7> other)
            =>
            throw new NotImplementedException();

        private Dependency<T1, T2, T3, T4, T5, T6, T7> InternalWith<T5, T6, T7>(
            Dependency<T5, T6, T7> other)
            =>
            new(
                firstResolver,
                secondResolver,
                thirdResolver,
                fourthResolver,
                other.InternalFirstResolver,
                other.InternalSecondResolver,
                other.InternalThirdResolver);
    }
}