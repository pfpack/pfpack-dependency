#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6, T7>
    {
        public Dependency<T1, T2, T3, T4, T5, T6, T7, T8> With<T8>(
            Dependency<T8> other)
            =>
            throw new NotImplementedException();

        private Dependency<T1, T2, T3, T4, T5, T6, T7, T8> InternalWith<T8>(
            Dependency<T8> other)
            =>
            new(
                firstResolver,
                secondResolver,
                thirdResolver,
                fourthResolver,
                fifthResolver,
                sixthResolver,
                seventhResolver,
                other.ToResolver());
    }
}