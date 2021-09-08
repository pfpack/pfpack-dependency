#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6, T7>
    {
        public Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> With<TRest>(
            Dependency<TRest> other)
            =>
            InnerWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> InnerWith<TRest>(
            Dependency<TRest> other)
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