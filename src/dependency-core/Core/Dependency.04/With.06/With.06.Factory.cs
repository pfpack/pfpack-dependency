#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        public Dependency<T1, T2, T3, T4, T5, T6> With<T5, T6>(
            Func<T5> fifth,
            Func<T6> sixth)
            =>
            InnerWith(
                fifth ?? throw new ArgumentNullException(nameof(fifth)),
                sixth ?? throw new ArgumentNullException(nameof(sixth)));

        private Dependency<T1, T2, T3, T4, T5, T6> InnerWith<T5, T6>(
            Func<T5> fifth,
            Func<T6> sixth)
            =>
            new(
                firstResolver,
                secondResolver,
                thirdResolver,
                fourthResolver,
                _ => fifth.Invoke(),
                _ => sixth.Invoke());
    }
}