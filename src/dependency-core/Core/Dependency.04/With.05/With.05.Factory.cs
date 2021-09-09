#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        public Dependency<T1, T2, T3, T4, T5> With<T5>(
            Func<T5> fifth)
            =>
            InnerWith(
                fifth ?? throw new ArgumentNullException(nameof(fifth)));

        private Dependency<T1, T2, T3, T4, T5> InnerWith<T5>(
            Func<T5> fifth)
            =>
            new(
                firstResolver,
                secondResolver,
                thirdResolver,
                fourthResolver,
                _ => fifth.Invoke());
    }
}